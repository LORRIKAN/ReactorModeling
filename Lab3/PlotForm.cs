using System;
using System.Windows.Forms;

namespace Researcher
{
    public partial class PlotForm : Form
    {
        public PlotForm()
        {
            InitializeComponent();
        }

        private string componentName;
        private XCoordType coordType;

        public string ComponentName
        {
            get => componentName;
            set
            {
                componentName = value;
                SetPlotTitleAndLabels();
            }
        }

        public XCoordType CoordType 
        { 
            get => coordType;
            set 
            { 
                coordType = value;
                SetPlotTitleAndLabels();
            } 
        }

        public double[] XValues { get; set; }

        public double[] YValues { get; set; }

        private void SetPlotTitleAndLabels()
        {
            plot.Title = $"График изменения концентрации компонента {componentName} по " +
                $"{(CoordType is XCoordType.Time ? "времени" : "длине реактора")}";
            plot.XLabel = $"{(CoordType is XCoordType.Time ? "Время, мин" : "Длина реактора, м")}";
            plot.YLabel = $"Концентрация компонента {componentName}, моль/л";
        }

        protected override void OnShown(EventArgs e)
        {
            plot.Plot.AddSignalXY(XValues, YValues);
            plot.Render();

            base.OnShown(e);
        }
    }

    public enum XCoordType
    {
        Time,
        Coordinate
    }
}
