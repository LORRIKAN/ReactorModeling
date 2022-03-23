//#nullable enable
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using CustomFormsElements;
//using MathModel;
//using Model;

//namespace Lab3
//{
//    public class VisualizationProcessor
//    {
//        public VisualizationProcessor(Form form, Func<IAsyncEnumerable<IntermediateResults>> calculationsFunc,
//            IEnumerable<Plot> plots, DataGridView? grid)
//        {
//            Form = form;

//            Plots = plots;
//            Grid = grid;

//            CalculationsFunc = calculationsFunc;
//        }

//        public event Func<IAsyncEnumerable<IntermediateResults>> CalculationsFunc;

//        public event Action<IEnumerable<Plot>, DataGridView?>? OnVisualizationStart;

//        public event Action<IEnumerable<Plot>, DataGridView?>? OnVisualizationFinished;

//        public async Task VisualizeAsync()
//        {
//            OnVisualizationStart?.Invoke(Plots, Grid);

//            await Task.Run(async () =>
//            {
//                Dictionary<IParameterInfo, IEnumerable<IParameterInfo>> paramsInfo = new(new ParamInfoComparer());

//                Dictionary<List<double>, List<List<double>>> resultsPlotFormat = new();

//                IAsyncEnumerable<IntermediateResults> results = CalculationsFunc();
//                IntermediateResults firstRes = await results.FirstAsync();

//                foreach (Parameter param in firstRes.IteratableParams)
//                {
//                    TryAddColumn(Grid, param, Form);

//                    TryAddParamInfo(param, firstRes.Results, paramsInfo, resultsPlotFormat);
//                }

//                foreach (Parameter result in firstRes.Results)
//                {
//                    TryAddColumn(Grid, result, Form);
//                }

//                await foreach (IntermediateResults res in results)
//                {
//                    var gridValues = new List<string>(res.IteratableParams.Count() + res.Results.Count());

//                    bool resultsAddedToGrid = false;

//                    for (int i = 0; i < res.IteratableParams.Count(); i++)
//                    {
//                        Parameter param = res.IteratableParams.ElementAt(i);

//                        gridValues.Add(param.ToStringWithPrecision(2));

//                        List<double> paramValues = resultsPlotFormat.Keys.ElementAt(i);

//                        paramValues.Add(param.Value);

//                        for (int j = 0; j < res.Results.Count(); j++)
//                        {
//                            Parameter result = res.Results.ElementAt(j);

//                            resultsPlotFormat[paramValues][j].Add(result.Value);

//                            if (!resultsAddedToGrid)
//                            {
//                                gridValues.Add(result.ToStringWithPrecision(2));
//                            }
//                        }

//                        resultsAddedToGrid = true;
//                    }

//                    TryAddRows(Grid, Form, gridValues);
//                }

//                for (int i = 0; i < paramsInfo.Keys.Count; i++)
//                {
//                    IParameterInfo param = paramsInfo.Keys.ElementAt(i);
//                    Plot? plot = Plots.ElementAtOrDefault(i);

//                    if (plot is not null)
//                    {
//                        List<double> paramValues = resultsPlotFormat.Keys.ElementAt(i);
//                        for (int j = 0; j < resultsPlotFormat[paramValues].Count; j++)
//                        {
//                            double[] values = resultsPlotFormat[paramValues][j].ToArray();
//                            string? valuesName = paramsInfo[param].ElementAt(j).DisplayedName;
//                            Form.Invoke(() =>
//                                { plot.Plot.AddSignalXY(paramValues.ToArray(), values, label: valuesName); }
//                            );

//                        }

//                        plot.Plot.Legend();
//                        plot.Render();
//                    }
//                }
//            });

//            OnVisualizationFinished?.Invoke(Plots, Grid);
//        }

//        private Form Form { get; set; }

//        private IEnumerable<Plot> Plots { get; set; }

//        private DataGridView? Grid { get; set; }

//        private static void TryAddParamInfo(IParameterInfo paramInfo,
//            IEnumerable<IParameterInfo> resultsInfo,
//            Dictionary<IParameterInfo, IEnumerable<IParameterInfo>> dict,
//            Dictionary<List<double>, List<List<double>>> values)
//        {
//            dict.TryAdd(paramInfo, resultsInfo);

//            values.TryAdd(new(), Enumerable.Range(1, resultsInfo.Count()).Select(i => new List<double>()).ToList());
//        }

//        private static void TryAddColumn(DataGridView? grid, Parameter param, Form form)
//        {
//            if (grid is not null)
//                form.Invoke(() =>
//                {
//                if (grid.Columns.Cast<DataGridViewColumn>().All(c => c.HeaderText != $"{param.DisplayedName}, {param.MeasureUnit}"))
//                        grid.Columns.Add(new DataGridViewTextBoxColumn()
//                        {
//                            HeaderText = $"{param.DisplayedName}, {param.MeasureUnit}",
//                            Name = $"{param.NameInMathModel}Col",
                            
//                        });
//                });
//        }

//        private static void TryAddRows(DataGridView? grid, Form form, IEnumerable<string> values)
//        {
//            if (grid is not null)
//                form.Invoke(() =>
//                {
//                    grid.Rows.Add(values.ToArray());
//                });
//        }

//        private class ParamInfoComparer : IEqualityComparer<IParameterInfo>
//        {
//            public bool Equals(IParameterInfo? x, IParameterInfo? y) => x is not null && y is not null &&
//                x.MeasureUnit == y.MeasureUnit &&
//                x.NameInMathModel == y.NameInMathModel &&
//                x.DisplayedName == y.DisplayedName;

//            public int GetHashCode([DisallowNull] IParameterInfo obj) =>
//                HashCode.Combine(obj.MeasureUnit, obj.NameInMathModel, obj.DisplayedName);
//        }
//    }
//}