﻿using Researcher.Plotting;
using System;
using System.Windows.Forms;

namespace Researcher.Plotting
{
    public partial class PlotForm : Form
    {
        public PlotForm()
        {
            InitializeComponent();
        }

        private PlotBuildMessage plotBuildMessage;

        public PlotBuildMessage PlotBuildMessage
        {
            get => plotBuildMessage;
            set
            {
                plotBuildMessage = value;
                SetPlotTitleAndLabels();
            }
        }

        private void SetPlotTitleAndLabels()
        {
            plot.Title = $"График изменения концентрации компонента {plotBuildMessage.ComponentName} по " +
                $"{(plotBuildMessage.CoordType is XCoordType.Time ? "времени" : "длине реактора")}";
            plot.XLabel = $"{(plotBuildMessage.CoordType is XCoordType.Time ? "Время, мин" : "Длина реактора, м")}";
            plot.YLabel = $"Концентрация компонента {plotBuildMessage.ComponentName}, моль/л";
        }

        protected override void OnShown(EventArgs e)
        {
            plot.Plot.AddSignal(plotBuildMessage.YValues, (plotBuildMessage.YValues.Length - 1) 
                / (plotBuildMessage.XValuesDelta * plotBuildMessage.YValues.Length));
            plot.Render();

            base.OnShown(e);
        }
    }
}