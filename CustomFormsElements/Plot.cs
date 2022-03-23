#nullable enable
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace CustomFormsElements
{
    public class Plot : FormsPlot
    {
        public Plot()
        {
            MouseMove += Plot_MouseMove;
        }

        public string? Title { get => title; set { title = value; Plot.Title(value); Render(); } }

        public string? XLabel { get => xLabel; set { xLabel = value; Plot.XLabel(value); Render(); } }

        public string? YLabel { get => yLabel; set { yLabel = value; Plot.YLabel(value); Render(); } }

        private string? yLabel;

        private string? xLabel;

        private string? title;

        private Crosshair? Crosshair { get; set; }

        private void Plot_MouseMove(object? sender, MouseEventArgs e)
        {
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = GetMouseCoordinates();

            double xyRatio = Plot.XAxis.Dims.PxPerUnit / Plot.YAxis.Dims.PxPerUnit;
            SignalPlotXY? plt = Plot.GetPlottables()
                .Where(p => p is SignalPlotXY).Select(p => (SignalPlotXY)p)
                .MinBy(p => 
                { 
                    (double x, double y, _) = p.GetPointNearestX(mouseCoordX);
                    return Math.Abs(mouseCoordX - x) + Math.Abs(mouseCoordY - y); 
                });

            if (plt is null)
                return;

            (double pointX, double pointY, _) = plt.GetPointNearestX(mouseCoordX);

            if (Crosshair is null || !Plot.GetPlottables().Any(p => ReferenceEquals(p, Crosshair)))
            {
                Crosshair = Plot.AddCrosshair(pointX, pointY);
                Crosshair.LineStyle = LineStyle.Solid;
            }
            else
            {
                Crosshair.X = pointX;
                Crosshair.Y = pointY;
            }

            Crosshair.Color = plt.Color;

            Render();
        }
    }
}