namespace Researcher.Plotting
{
    public class PlotBuildMessage
    {
        public string ComponentName { get; set; }

        public XCoordType CoordType { get; set; }

        public double XValuesDelta { get; set; }

        public double[] YValues { get; set; }
    }
}
