#nullable enable
using CustomFormsElements;
using DataValidation;
using Model;
using Researcher.Export;
using Researcher.Plotting;
using Researcher.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    return (false, "Число Куранта должно находиться строго между 0 и 1");

                return (true, null);
            });
        }

        #region Calc&Visualize
        private void SwitchControls(bool enabled)
        {
            if (enabled)
                startCalcsButt.TryEnable();
            else
                startCalcsButt.Disable();

            exportButt.Enabled = enabled;
        }

        private ResultsForm? LastCalcResultForm { get; set; }

        private List<Form> OpenedForms { get; set; } = new();

        private IEnumerable<Parameter> LastInputs { get; set; } = null!;

        private async void startCalcsButt_Click(object sender, EventArgs e)
        {
            SwitchControls(false);
            OpenedForms.Clear();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            Task<(CalcResult? calcRes, string? error)> calcTask = StartCalcTask(cancelTokenSource.Token);

            async IAsyncEnumerable<(int progressVal, string? progressStr, bool error, bool cancelable)>
                CalcAndVisualize()
            {
                yield return (0, "Идут вычисления...", false, true);
                var (calcResult, errorMsg) = await calcTask;
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    yield return (0, errorMsg, true, false);
                    yield break;
                }
                if (calcResult is null)
                    yield break;

                int progress = 0;
                await foreach ((int progressVal, string? progressStr, bool error) in
                    Visualize(calcResult ?? new(), cancelTokenSource.Token))
                {
                    progress = progressVal + 1;
                    yield return (progress, progressStr, error, true);
                }

                yield return (progress + 1, "Моделирование и визуализация завершены", false, false);
            }

            int maxProgress = 1 + tPlots.CheckedItems.Count + xPlots.CheckedItems.Count +
                valuesTables.CheckedItems.Count;

            var res = MessageDialog.ShowNormalAwaitDialog(CalcAndVisualize, 0, maxProgress, this,
                "Процесс моделирования и визуализации", "Идёт процесс моделирования и визуализации...", aboveAll: true);

            if (res == TaskDialogButton.Cancel || res == TaskDialogButton.Close)
            {
                if (res == TaskDialogButton.Cancel)
                    cancelTokenSource.Cancel();

                startCalcsButt.Enabled = true;
                return;
            }

            CalcResult? calcRes = (await calcTask).calcRes;

            LastCalcResultForm = new ResultsForm { Results = calcRes!.Value.Results };
            LastCalcResultForm.Show();

            SwitchControls(true);
        }

        private async IAsyncEnumerable<(int progressVal, string? progressStr, bool error)>
            Visualize(CalcResult calcResult, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            static double[] GetXValues(CalcResult calcResult, string componentName,
                XCoordType coordType)
            {
                return componentName switch
                {
                    "A" => coordType is XCoordType.Time ? calcResult.CA.Select(c => c.Last()).ToArray() : calcResult.CA.Last(),
                    "B" => coordType is XCoordType.Time ? calcResult.CB.Select(c => c.Last()).ToArray() : calcResult.CB.Last(),
                    "C" => coordType is XCoordType.Time ? calcResult.CC.Select(c => c.Last()).ToArray() : calcResult.CC.Last(),
                    _ => Enumerable.Empty<double>().ToArray()
                };
            }

            int totalProgress = 0;
            foreach (var pr in tPlots.CheckedItems.OfType<PlotReservation>()
                .Concat(xPlots.CheckedItems.OfType<PlotReservation>()))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return (totalProgress++, $"Идёт построение {pr.Name}", false);
                string? errorMsg = null;
                try
                {
                    var message = await Task.FromResult(new PlotBuildMessage
                    {
                        ComponentName = pr.ComponentName,
                        CoordType = pr.CoordType,
                        XValuesDelta = calcResult.Results
                            .First(p => p.NameInMathModel == $"{(pr.CoordType is XCoordType.Time ? "deltaT" : "deltaX")}"),
                        YValues = GetXValues(calcResult, pr.ComponentName, pr.CoordType)
                    });

                    RegisterAndShowForm(new PlotForm { PlotBuildMessage = message });
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
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return (totalProgress++, $"Идёт построение {pr.Name}", false);
                string? errorMsg = null;
                try
                {
                    var message = await Task.FromResult(new TableBuildMessage
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
                    });

                    RegisterAndShowForm(new ValuesTableForm { TableBuildMessage = message });
                }
                catch (Exception ex) { errorMsg = ex.Message; }

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    yield return (totalProgress, errorMsg, true);
                    yield break;
                }
            }
        }

        private void RegisterAndShowForm(Form form)
        {
            form.FormClosed += (sender, _) => OpenedForms.Remove((Form)sender!);
            OpenedForms.Add(form);

            form.Show();
        }

        private Task<(CalcResult? calcResult, string? errorMsg)>
            StartCalcTask(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                CalcResult? res = null;
                string? errorMsg = null;

                try
                {
                    Invoke(() => LastInputs = this.GetChildControlsOfType<ParameterInput>()
                    .Select(pi => pi.Parameter with { Value = pi.Parameter.Value }));

                    res = new CalculationsProcessor()
                    .StartCalculations(LastInputs, cancellationToken);
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }

                return (res, errorMsg);
            }, cancellationToken);
        }
        #endregion

        #region Export
        private void exportButt_Click(object sender, EventArgs e)
        {
            using var cntrlsSwitcher = new ControlsSwitcher(SwitchControls);
            if (saveFileDialog.ShowDialog() is not DialogResult.OK)
            {
                SwitchControls(true);
                return;
            }

            if (IsFileLocked(new FileInfo(saveFileDialog.FileName)))
            {
                MessageDialog.ShowMessage(MessageType.Error, this, "Экспорт", "Экспорт в файл не удался",
                    "Файл уже открыт или используется другой программой", aboveAll: true);
                SwitchControls(true);
                return;
            }

            CancellationTokenSource cancellationTokenSource = new();

            async IAsyncEnumerable<(int progressVal, string? msg, bool error, bool cancelable)>
                Export()
            {
                yield return (0, "Сбор данных...", false, false);
                foreach (ValuesTableForm form in OpenedForms.OfType<ValuesTableForm>())
                {
                    if (form.Data.RowCount is 0 || form.Data.ColumnCount is 0)
                        form.BuildTable();
                }

                var message = new ExportMessage
                {
                    Title = "Результаты моделирования трубчатого реактора с механизмом протекания реакции: A+B->C, C->E+2F",
                    FilePath = saveFileDialog.FileName,
                    Inputs = LastInputs,
                    Outputs = LastCalcResultForm.GetChildControlsOfType<ParameterOutput>().Select(pi => pi.Parameter),
                    Plots = OpenedForms.OfType<PlotForm>().Select(pf => pf.Plot),
                    Tables = OpenedForms.OfType<ValuesTableForm>().Select(tf => new TableExportMessage
                    {
                        Data = tf.Data,
                        HLabel = tf.HLabel,
                        HMult = tf.DeltaXMult,
                        VLabel = tf.VLabel,
                        VMult = tf.DeltaTMult,
                        Name = tf.TableName,
                    }),
                };

                await foreach ((int progressVal, string msg, bool cancelable) in ExportProcessor
                    .Export(message, cancellationTokenSource.Token))
                {
                    yield return (progressVal + 1, msg, false, cancelable);
                }
            }

            int max = OpenedForms.Count + 2;

            TaskDialogButton res = MessageDialog.ShowNormalAwaitDialog(Export, 0, max, this, "Процесс экспорта",
                "Пожалуйста подождите, идёт процесс экспорта...",
                aboveAll: true);

            if (res == TaskDialogButton.Cancel)
                cancellationTokenSource.Cancel();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        #endregion

        private class ControlsSwitcher : IDisposable
        {
            private Action<bool> Switcher { get; set; }

            public ControlsSwitcher(Action<bool> switcher)
            {
                Switcher = switcher;
                Switcher(false);
            }

            public void Dispose()
            {
                Switcher(true);
            }
        }
    }
}
