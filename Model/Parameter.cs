#nullable enable
using DataValidation;

namespace Model
{
    public record class Parameter
    {
        public string? MeasureUnit { get; set; }

        public string? DisplayedName { get; set; }

        public string? NameInMathModel { get; set; }

        public double Value { get; set; }

        public int? DecimalPlaces { get; set; } = 2;

        public bool IsOptional { get; set; }

        public ParseAndCheckConditions ParseAndCheckConditions { get; set; } = new(
            DoubleParseAndCheckConditions.Parse, DoubleParseAndCheckConditions.MoreThanZeroCondition);

        public (bool parsed, double result, string? errorMessage) TrySetValue(string strToParse)
        {
            (bool parsed, double result, string? errorMessage) = ParseAndCheckConditions.TryParseAndValidate(strToParse);

            if (parsed)
                Value = result;

            return (parsed, result, errorMessage);
        }

        public static implicit operator double(Parameter parameter) => parameter.Value;

        public override string ToString()
        {
            if (DecimalPlaces is not null)
                return Value.ToString($"F{DecimalPlaces}");
            else
                return Value.ToString();
        }
    }
}