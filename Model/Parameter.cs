#nullable enable
using DataValidation;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Parameter
    {
        public string? MeasureUnit { get; set; }

        public string? DisplayedName { get; set; }

        public string? NameInMathModel { get; set; }

        public double Value { get; set; }

        public int? DecimalPlaces { get; set; }

        public bool IsOptional { get; set; }

        public ParseAndCheckConditions ParseAndCheckConditions { get; set; } = new(
            DoubleParseAndCheckConditions.Parse, DoubleParseAndCheckConditions.NotLessThanZeroCondition);

        public string ToStringWithPrecision(int? decimalPlaces = null)
        {
            decimalPlaces ??= DecimalPlaces;

            if (decimalPlaces is not null)
                return Value.ToString($"F{DecimalPlaces}");
            else
                return Value.ToString();
        }

        public (bool parsed, double result, string? errorMessage) TrySetValue(string strToParse)
        {
            (bool parsed, double result, string? errorMessage) = ParseAndCheckConditions.TryParseAndValidate(strToParse);

            if (parsed)
                Value = result;

            return (parsed, result, errorMessage);
        }

        public static implicit operator double(Parameter parameter) => parameter.Value;
    }
}