#nullable enable
using CustomFormsElements;
using DataValidation;
using Model;
using Researcher.Plotting;
using Researcher.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Researcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ConfigureCheckConditionsForParams();
            InitializeListBoxes();

            startCalcsButt.AddMasterControlsRange(this.GetChildControlsOfType<ParameterInput>().ToArray());
        }

        private void InitializeListBoxes()
        {
            var tPlotsReservations = new[] 
            { 
                new PlotReservation { ComponentName = "A", CoordType = XCoordType.Time },
                new PlotReservation { ComponentName = "B", CoordType = XCoordType.Time },
                new PlotReservation { ComponentName = "C", CoordType = XCoordType.Time }
            };

            var xPlotsReservations = new[]
            {
                new PlotReservation { ComponentName = "A", CoordType = XCoordType.ReactorLength },
                new PlotReservation { ComponentName = "B", CoordType = XCoordType.ReactorLength },
                new PlotReservation { ComponentName = "C", CoordType = XCoordType.ReactorLength }
            };

            var tablesReservations = new[]
{
                new TableReservation { ComponentName = "A" },
                new TableReservation { ComponentName = "B" },
                new TableReservation { ComponentName = "C" }
            };

            tPlots.DataSource = tPlotsReservations;
            tPlots.DisplayMember = "Name";

            xPlots.DataSource = xPlotsReservations;
            xPlots.DisplayMember = "Name";

            valuesTables.DataSource = tablesReservations;
            valuesTables.DisplayMember = "Name";
        }

        private void ConfigureCheckConditionsForParams()
        {
            qmax.Parameter.ParseAndCheckConditions = new ParseAndCheckConditions(UIntParseAndCheckConditions.Parse);

            Ku.Parameter.ParseAndCheckConditions.CheckFuncs.Add(v =>
            {
                if (v is 0d or >= 1d)
                    return (false, "Число Куранта должно находится строго между 0 и 1");

                return (true, null);
            });
        }

        private void SwitchControls(bool enabled)
        {
            if (enabled)
                startCalcsButt.TryEnable();
            else
                startCalcsButt.Disable();

            exportButt.Enabled = enabled;
        }

        private async void startCalcsButt_Click(object sender, EventArgs e)
        {
            SwitchControls(false);

            var cancelTokenSource = new CancellationTokenSource();
            var calcTask = StartCalcTask(cancelTokenSource.Token);

            async IAsyncEnumerable<(int progressVal, string? progressStr, bool error)> 
                CalcAndVisualize()
            {
                yield return (0, "Идут вычисления...", false);
                var (calcResult, errorMsg) = await calcTask;
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    yield return (0, errorMsg, true);
                    yield break;
                }

                await foreach ((int progressVal, string? progressStr, bool error) in Visualize(calcResult))
                    yield return (progressVal + 1, progressStr, error);
            }

            int maxProgress = 1 + tPlots.CheckedItems.Count + xPlots.CheckedItems.Count +
                valuesTables.CheckedItems.Count;

            var res = MessageDialog.ShowNormalAwaitDialog(true,
                CalcAndVisualize, 0, maxProgress, this, "Процесс моделирования и " +
                "визуализации", "Идёт процесс моделирования и визуализации...", aboveAll: true);

            if (res == TaskDialogButton.Cancel || res == TaskDialogButton.Close)
            {
                exportButt.Enabled = false;
                if (res == TaskDialogButton.Cancel)
                    cancelTokenSource.Cancel();
            }

            new ResultsForm() { Results = (await calcTask).calcResult.Results }.Show();

            SwitchControls(true);
        }

        private async IAsyncEnumerable<(int progressVal, string? progressStr, bool error)> 
            Visualize(CalcResult calcResult)
        {
            static async Task<double[]> GetXValues(CalcResult calcResult, string componentName, 
                XCoordType coordType)
            {
                return await Task.Run(() => componentName switch
                {
                    "A" => coordType is XCoordType.Time ? calcResult.CA.Select(c => c.Last()).ToArray() : calcResult.CA.Last(),
                    "B" => coordType is XCoordType.Time ? calcResult.CB.Select(c => c.Last()).ToArray() : calcResult.CB.Last(),
                    "C" => coordType is XCoordType.Time ? calcResult.CC.Select(c => c.Last()).ToArray() : calcResult.CC.Last(),
                    _ => Enumerable.Empty<double>().ToArray()
                });
            }

            int totalProgress = 0;
            foreach (var pr in tPlots.CheckedItems.OfType<PlotReservation>()
                .Concat(xPlots.CheckedItems.OfType<PlotReservation>()))
            {
                yield return (totalProgress++, $"Идёт построение {pr.Name}", false);
                string? errorMsg = null;
                try
                {
                    var message = new PlotBuildMessage
                    {
                        ComponentName = pr.ComponentName,
                        CoordType = pr.CoordType,
                        XValuesDelta = calcResult.Results
                            .First(p => p.NameInMathModel == $"{(pr.CoordType is XCoordType.Time ? "deltaT" : "deltaX")}"),
                        YValues = await GetXValues(calcResult, pr.ComponentName, pr.CoordType)
                    };

                    new PlotForm { PlotBuildMessage = message }.Show();
                }
                catch (Exception ex) { errorMsg = ex.Message; }

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    yield return (totalProgress, errorMsg, true);
                    yield break;
                }
            }

            foreach (var pr in valuesTables.CheckedItems.OfType<TableReservation>())
            {
                yield return (totalProgress++, $"Идёт построение {pr.Name}", false);
                string? errorMsg = null;
                try
                {
                    var message = new TableBuildMessage
                    {
                        ComponentName = pr.ComponentName,
                        DeltaT = calcResult.Results
                            .First(p => p.NameInMathModel == "deltaT"),
                        DeltaX = calcResult.Results
                            .First(p => p.NameInMathModel == "deltaX"),
                        Values = pr.ComponentName switch 
                            { 
                                "A" => calcResult.CA,
                                "B" => calcResult.CB,
                                "C" => calcResult.CC,
                                _ => Enumerable.Empty<double[]>().ToArray()
                            },
                        ValuesDecimalPlaces = 2
                    };

                    new ValuesTableForm { TableBuildMessage = message }.Show();
                }
                catch (Exception ex) { errorMsg = ex.Message; }

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    yield return (totalProgress, errorMsg, true);
                    yield break;
                }
            }
        }

        private Task<(CalcResult calcResult, string? errorMsg)> 
            StartCalcTask(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var res = new CalcResult();
                string? errorMsg = null;

                try
                {
                    IEnumerable<Parameter> parameters = null!;
                    Invoke(() => parameters = this.GetChildControlsOfType<ParameterInput>()
                    .Select(pi => pi.Parameter));

                    res = new CalculationsProcessor()
                    .StartCalculations(parameters, cancellationToken);
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }

                return (res, errorMsg);
            }, cancellationToken);
        }
    }
}
