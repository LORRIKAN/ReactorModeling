#nullable enable
using DataValidation;
using Model;

namespace CustomFormsElements
{
    public class UIntParamInput : ParameterInput
    {
        public UIntParamInput()
        {
            ParseAndCheckConditions parseAndCheckConditions =
                new(UIntParseAndCheckConditions.Parse);

            Parameter = new Parameter()
            {
                ParseAndCheckConditions = parseAndCheckConditions
            };
        }
    }
}
