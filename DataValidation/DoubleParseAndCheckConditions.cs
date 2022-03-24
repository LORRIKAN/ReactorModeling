#nullable enable

namespace DataValidation
{
    public static class DoubleParseAndCheckConditions
    {

        public static (bool parsed, double parsedValue, string? errorMessage) Parse(string stringToParseAndValidate)
        {
            try
            {
                stringToParseAndValidate = stringToParseAndValidate.Replace('.', ',');
                double parsedValue = double.Parse(stringToParseAndValidate);
                return (true, parsedValue, null);
            }
            catch
            {
                return (false, default, "Заданное значение не дробное");
            }
        }

        public static (bool result, string? errorMessage) NotLessThanZeroCondition(double val)
        {
            if (val < 0)
                return (false, "Значение не может быть меньше нуля");
            else
                return (true, null);
        }

        public static (bool result, string? errorMessage) MoreThanZeroCondition(double val)
        {
            if (val <= 0)
                return (false, "Значение должно быть строго больше нуля");
            else
                return (true, null);
        }
    }
}
