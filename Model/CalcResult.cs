using System.Collections.Generic;

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