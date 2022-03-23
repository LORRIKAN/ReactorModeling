#nullable enable
using System;
using System.Collections.Generic;

namespace DataValidation
{
    public class ParseAndCheckConditions
    {
        public ParseAndCheckConditions(Func<string, (bool parsed, double result, string? errorMessage)> parseFunc,
            params Func<double, (bool result, string? errorMessage)>[] checkFuncs)
        {
            ParseFunc = parseFunc;
            CheckFuncs = new(checkFuncs);
        }

        public Func<string, (bool parsed, double result, string? errorMessage)> ParseFunc { get; set; }

        public HashSet<Func<double, (bool result, string? errorMessage)>> CheckFuncs { get; set; }

        public (bool parsed, double result, string? errorMessage) TryParseAndValidate(string str)
        {
            (bool parsed, double parsedValue, string? errorMessage) = ParseFunc(str);

            if (!parsed)
            {
                return (parsed, parsedValue, errorMessage);
            }

            foreach (Func<double, (bool result, string? errorMessage)> condition in CheckFuncs)
            {
                bool result;
                (result, errorMessage) = condition(parsedValue);

                if (result is false)
                    return (result, parsedValue, errorMessage);
            }

            return (true, parsedValue, string.Empty);
        }
    }
}
