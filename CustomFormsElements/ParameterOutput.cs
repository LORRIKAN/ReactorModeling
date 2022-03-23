#nullable enable
using System.ComponentModel;

namespace CustomFormsElements
{
    public partial class ParameterOutput : ParameterInput
    {
        public ParameterOutput()
        {
            InitializeComponent();

            textBox.Enabled = false;
        }

        protected override void TextBox_Validating(object? sender, CancelEventArgs e)
        {

        }
    }
}
