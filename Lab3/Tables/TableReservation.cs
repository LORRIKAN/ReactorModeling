using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher.Tables
{
    public class TableReservation
    {
        public string ComponentName { get; set; }

        public string Name => $"Таблица значений концентраций компонента {ComponentName}";
    }
}