#nullable enable
using DataValidation;
using Model;

namespace CustomFormsElements
{
    public class DoubleParamInput : ParameterInput
    {
        public DoubleParamInput()
        {
            ParseAndCheckConditions parseAndCheckConditions =
                new(DoubleParseAndCheckConditions.Parse,
                DoubleParseAndCheckConditions.NotLessThanZeroCondition);

            Parameter = new Parameter()
            {
                ParseAndCheckConditions = parseAndCheckConditions
            };
        }
    }
}
