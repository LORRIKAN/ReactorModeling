using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct CalcResult
    {
        public IEnumerable<Parameter> Results { get; set; }

        public double[][] CA { get; set; }

        public double[][] CB { get; set; }

        public double[][] CC { get; set; }
    }
}