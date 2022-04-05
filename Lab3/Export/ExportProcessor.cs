#nullable enable
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using CustomFormsElements;
using Model;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Researcher.Export
{
    public static class ExportProcessor
    {
        public static async IAsyncEnumerable<(int progress, string message, bool cancelable)> Export(ExportMessage message,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using var wb = new XLWorkbook();
            IXLWorksheet ws = wb.AddWorksheet();

            int progress = 0;

            ws.Cell(1, 1).SetValue(message.Title);
            yield return (progress++, "Экспорт входных параметров...", true);
            await ExportParams(2, 1, "Входные параметры", message.Inputs.ToArray(), ws);
            if (cancellationToken.IsCancellationRequested)
                yield break;

            yield return (progress++, "Экспорт результатов моделирования...", true);
            await ExportParams(2, 4, "Результаты моделирования", message.Outputs.ToArray(), ws);
            if (cancellationToken.IsCancellationRequested)
                yield break;

            IXLCell exportCell = ws.Cell(1, 7);
            foreach (Plot plot in message.Plots)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;
                yield return (progress++, $"Экспорт {plot.Title}...", true);
                IXLCell bottomRightCell = await ExportPlot(exportCell, plot, ws);
                exportCell = ws.Cell(1, bottomRightCell.Address.ColumnNumber + 2);
            }

            exportCell = ws.Cell(20, 7);

            foreach (TableExportMessage table in message.Tables)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;
                yield return (progress++, $"Экспорт {table.Name}...", true);
                IXLCell lastCell = ExportTable(exportCell, table, ws);
                exportCell = ws.Cell(exportCell.Address.RowNumber, lastCell.Address.ColumnNumber + 2);
            }

            if (cancellationToken.IsCancellationRequested)
                yield break;

            yield return (progress++, "Сохранение...", false);
            await Task.Run(() => wb.SaveAs(message.FilePath), cancellationToken);
            yield return (progress, "Экспорт завершён", false);
        }

        private static async Task ExportParams(int row, int col, string label,
            Parameter[] parameters, IXLWorksheet ws)
        {
            await Task.Run(() =>
            {
                IXLCell nameCell = ws.Cell(row, col).SetValue(label);

                for (int i = 0; i < parameters.Length; i++)
                {
                    ws.Cell(row + i + 1, col).SetValue($"{parameters[i].DisplayedName}, {parameters[i].MeasureUnit}");

                    ws.Cell(row + i + 1, col + 1).SetValue(parameters[i].Value);
                }

                ws.Column(nameCell.Address.ColumnNumber).AdjustToContents();
            });
        }

        private static async Task<IXLCell> ExportPlot(IXLCell cell, Plot plot, IXLWorksheet ws)
        {
            return await Task.Run(() =>
            {
                static void SetPlotCrosshair(Plot plot, bool enabled)
                {
                    if (plot.Crosshair is not null)
                        plot.Crosshair.IsVisible = enabled;
                }

                plot.Invoke(() => SetPlotCrosshair(plot, false));
                Bitmap plotImg = plot.Invoke(() => plot.Plot.GetBitmap());
                plot.Invoke(() => SetPlotCrosshair(plot, true));

                using var stream = new MemoryStream();
                plotImg.Save(stream, ImageFormat.Png);
                IXLPicture pict = ws.AddPicture(stream);

                pict = pict.MoveTo(cell, ws.Cell(cell.Address.RowNumber + 18, cell.Address.ColumnNumber + 10));
                pict.Placement = XLPicturePlacement.MoveAndSize;
                return pict.BottomRightCell;
            });
        }

        private static IXLCell ExportTable(IXLCell cell, TableExportMessage table, IXLWorksheet ws)
        {
            cell.SetValue($"{table.Name} ({table.HLabel} с множителем {table.HMult}, " +
                $"{table.VLabel} с множителем {table.VMult})");

            for (int i = 0; i < table.Data.ColumnCount; i++)
                ws.Cell(cell.Address.RowNumber + 1, cell.Address.ColumnNumber + i + 1)
                    .SetValue(double.Parse(table.Data.Columns[i].HeaderText ?? ""));

            for (int i = 0; i < table.Data.RowCount; i++)
            {
                ws.Cell(cell.Address.RowNumber + i + 2, cell.Address.ColumnNumber)
                    .SetValue(double.Parse(table.Data.Rows[i].HeaderCell.Value.ToString() ?? ""));

                for (int j = 0; j < table.Data.ColumnCount; j++)
                {
                    ws.Cell(cell.Address.RowNumber + i + 2, cell.Address.ColumnNumber + j + 1)
                        .SetValue(double.Parse(table.Data[j, i].Value.ToString() ?? ""));
                }
            }

            ws.Range(cell, ws.Cell(cell.Address.RowNumber, cell.Address.ColumnNumber + table.Data.ColumnCount)).Merge();

            return ws.LastCellUsed();
        }
    }
}
