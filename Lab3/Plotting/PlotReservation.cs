using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher.Plotting
{
    public class PlotReservation
    {
        public string ComponentName { get; set; }

        public XCoordType CoordType { get; set; }

        public string Name => $"График изменения концентрации компонента " +
            $"{ComponentName} по {(CoordType is XCoordType.Time ? "времени" : "длине реактора")}";
    }
}