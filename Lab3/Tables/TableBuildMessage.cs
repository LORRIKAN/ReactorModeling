using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher.Tables
{
    public class TableBuildMessage
    {
        public string ComponentName { get; set; }

        public Parameter DeltaT { get; set; }

        public Parameter DeltaX { get; set; }

        public double[][] Values { get; set; }

        public int? ValuesDecimalPlaces { get; set; }
    }
}
