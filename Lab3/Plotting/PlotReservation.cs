namespace Researcher.Plotting
{
    public class PlotReservation
    {
        public string ComponentName { get; set; }

        public XCoordType CoordType { get; set; }

        public string Name => $"График изменения {(CoordType is XCoordType.Time ? "выходной" : "конечной")} " +
            $"концентрации компонента {ComponentName} " +
            $"по {(CoordType is XCoordType.Time ? "времени" : "длине реактора")}";
    }
}