#nullable enable
using System;

namespace DataValidation
{
    public static class UIntParseAndCheckConditions
    {
        public static (bool parsed, double parsedValue, string? errorMessage) Parse(string stringToParseAndValidate)
        {
            try
            {
                int parsedValue = int.Parse(stringToParseAndValidate);
                if (parsedValue < 0)
                    throw new Exception();
                return (true, parsedValue, null);
            }
            catch
            {
                return (false, default, "Заданное значение не является положительным и целочисленным.");
            }
        }
    }
}
