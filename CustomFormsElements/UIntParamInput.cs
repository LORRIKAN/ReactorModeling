#nullable enable
using DataValidation;
using Model;
using System.ComponentModel;

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
