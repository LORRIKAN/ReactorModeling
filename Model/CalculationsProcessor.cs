using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Model
{
    public class CalculationsProcessor
    {
        private Parameter D { get; set; } = new() { NameInMathModel = "D" };
        private Parameter L { get; set; } = new() { NameInMathModel = "L" };
        private Parameter Q { get; set; } = new() { NameInMathModel = "Q" };
        private Parameter Cain { get; set; } = new() { NameInMathModel = "Cain" };
        private Parameter Cbin { get; set; } = new() { NameInMathModel = "Cbin" };
        private Parameter T { get; set; } = new() { NameInMathModel = "T" };
        private Parameter k01 { get; set; } = new() { NameInMathModel = "k01" };
        private Parameter Ea1 { get; set; } = new() { NameInMathModel = "Ea1" };
        private Parameter k02 { get; set; } = new() { NameInMathModel = "k02" };
        private Parameter Ea2 { get; set; } = new() { NameInMathModel = "Ea2" };
        private Parameter deltaX0 { get; set; } = new() { NameInMathModel = "deltaX0" };
        private Parameter Ku { get; set; } = new() { NameInMathModel = "Ku" };
        private Parameter emax { get; set; } = new() { NameInMathModel = "emax" };
        private IntParameter qmax { get; set; } = new() { NameInMathModel = "qmax" };

        public CalcResult? StartCalculations(IEnumerable<Parameter> inputParams, CancellationToken cancellationToken)
        {
            SetParams(inputParams);
            var timer = new Stopwatch();
            timer.Start();

            var S = new Parameter { Value = (Math.PI * Math.Pow(D, 2)) / 4, NameInMathModel = "S" };

            var u = new Parameter { Value = (Q * Math.Pow(10, -3)) / S, NameInMathModel = "u" };

            var tauR = new Parameter { Value = L / u, NameInMathModel = "tauR" };

            var teta = new Parameter { Value = 2 * tauR, NameInMathModel = "teta" };

            var k1 = new Parameter { Value = k01 * Math.Exp(-(Ea1 / (8.31 * (T + 273)))), NameInMathModel = "k1" };

            var k2 = new Parameter { Value = k02 * Math.Exp(-(Ea2 / (8.31 * (T + 273)))), NameInMathModel = "k2" };

            var q = new IntParameter { Value = 0, NameInMathModel = "q" };

            var e = new Parameter { Value = 2 * emax, NameInMathModel = "e" };

            var deltaX = new Parameter { Value = deltaX0, NameInMathModel = "deltaX" };

            var deltaT = new Parameter { Value = (Ku * deltaX) / u, NameInMathModel = "deltaT" };

            var M = new IntParameter { Value = (int)Math.Round(L / deltaX) + 1, NameInMathModel = "M" };

            var N = new IntParameter { Value = (int)Math.Round(teta / deltaT) + 1, NameInMathModel = "N" };

            var ea = new Parameter { NameInMathModel = "ea", DecimalPlaces = 4 };

            var CCmax = new Parameter { NameInMathModel = "CCmax" };

            double[][] CA = null;
            double[][] CB = null;
            double[][] CC = null;

            int M1 = N;
            int N1 = M;
            double[][] CC1 = null;

            for (; e >= emax && q <= qmax; q.Value++)
            {
                if (q != 0)
                {
                    deltaX.Value /= 2;
                    deltaT.Value /= 2;

                    M.Value = M.Value * 2 - 1;
                    N.Value = N.Value * 2 - 1;
                }

                CA = InitializeArray(N, M);
                CB = InitializeArray(N, M);
                CC = InitializeArray(N, M);

                for (int i = 0; i < M; i++)
                {
                    CA[0][i] = 0;
                    CB[0][i] = 0;
                    CC[0][i] = 0;
                }

                for (int j = 1; j < N; j++)
                {
                    CA[j][0] = Cain;
                    CB[j][0] = Cbin;
                    CC[j][0] = 0;
                }

                if (cancellationToken.IsCancellationRequested)
                    return null;

                for (int j = 0; j < N - 1; j++)
                {
                    for (int i = 1; i < M - 1; i++)
                    {
                        CA[j + 1][i] = 0.5 * ((CA[j][i - 1] + CA[j][i + 1]) * (1 - 0.5 * (k1 * deltaT * (CB[j][i - 1] + CB[j][i + 1]))) - Ku * (CA[j][i + 1] - CA[j][i - 1]));
                        CB[j + 1][i] = 0.5 * ((CB[j][i - 1] + CB[j][i + 1]) * (1 - 0.5 * (k1 * deltaT * (CA[j][i - 1] + CA[j][i + 1]))) - Ku * (CB[j][i + 1] - CB[j][i - 1]));
                        CC[j + 1][i] = 0.5 * ((CC[j][i - 1] + CC[j][i + 1]) * (1 - k2 * deltaT) - Ku * (CC[j][i + 1] - CC[j][i - 1]) + 0.5 * (k1 * deltaT * (CA[j][i - 1] + CA[j][i + 1]) * (CB[j][i - 1] + CB[j][i + 1])));
                    }

                    CA[j + 1][M - 1] = CA[j][M - 1] * (1 - k1 * deltaT * CB[j][M - 1]) - Ku * (CA[j][M - 1] - CA[j][M - 2]);
                    CB[j + 1][M - 1] = CB[j][M - 1] * (1 - k1 * deltaT * CA[j][M - 1]) - Ku * (CB[j][M - 1] - CB[j][M - 2]);
                    CC[j + 1][M - 1] = CC[j][M - 1] * (1 - k2 * deltaT) - Ku * (CC[j][M - 1] - CC[j][M - 2]) + k1 * deltaT * CA[j][M - 1] * CB[j][M - 1];
                }

                if (cancellationToken.IsCancellationRequested)
                    return null;

                if (q != 0)
                {
                    ea.Value = Math.Sqrt(Disp(N1, M1, CC, CC1) / ((double)(M1 - 1) * (N1 - 1)));
                    CCmax.Value = Max(CC);
                    e.Value = (ea / CCmax) * 100;
                }

                CC1 = Copy(CC);
                M1 = M;
                N1 = N;
            }

            if (q > qmax)
                throw new Exception("Решение с погрешностью, не превосходящей предельно допустимую погрешность, не получено");

            var tCalc = new Parameter { Value = timer.Elapsed.TotalSeconds, NameInMathModel = "tCalc" };

            q.Value--;
            M.Value--;
            N.Value--;

            return new CalcResult
            {
                CA = CA,
                CB = CB,
                CC = CC,
                Results = new[] { S, u, k1, k2, CCmax, deltaX, deltaT, M, N, q, ea, e, tauR, teta, tCalc }
            };
        }

        private static double[][] InitializeArray(int N, int M)
        {
            return Enumerable
              .Range(0, N)
              .Select(i => new double[M])
              .ToArray();
        }

        private static double Max(double[][] CC)
        {
            return CC.Max(v => v.Max());
        }

        private static double[][] Copy(double[][] CC)
        {
            int N = CC.GetLength(0);

            return Enumerable
              .Range(0, N)
              .Select((_, i) => CC[i].ToArray())
              .ToArray();
        }

        private static double Disp(int N1, int M1, double[][] CC, double[][] CC1)
        {
            double disp = 0;

            for (int j = 1; j < N1; j++)
                for (int i = 1; i < M1; i++)
                    disp += Math.Pow(CC[2 * j][2 * i] - CC1[j][i], 2);

            return disp;
        }

        private void SetParams(IEnumerable<Parameter> inputParams)
        {
            foreach (Parameter parameter in GetType().GetRuntimeProperties()
                .Where(prop => prop.GetValue(this) is Parameter parameter).Select(prop => (Parameter)prop.GetValue(this)))
            {
                if (inputParams.FirstOrDefault(p => p.NameInMathModel == parameter.NameInMathModel) is Parameter inputParam)
                    parameter.Value = inputParam.Value;
                else
                    throw new Exception($"Не было передано значение параметра {parameter.NameInMathModel}");
            }
        }

        private record class IntParameter : Parameter
        {
            public new int Value { get => (int)base.Value; set => base.Value = value; }

            public static implicit operator int(IntParameter parameter) => parameter.Value;

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}