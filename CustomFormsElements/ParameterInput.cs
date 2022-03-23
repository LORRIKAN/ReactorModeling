#nullable enable
using DataValidation;
using Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomFormsElements
{
    public partial class ParameterInput : UserControl
    {
        public ParameterInput()
        {
            InitializeComponent();
            textBox.Validating += TextBox_Validating;
        }

        public new void Refresh()
        {
            measureUnitLbl.Text = parameter?.MeasureUnit ?? string.Empty;
            paramNameLbl.Text = parameter?.DisplayedName ?? string.Empty;
            string value;
            if (parameter?.Value is not null)
                value = parameter.ToStringWithPrecision();
            else
                value = string.Empty;

            textBox.Text = value;
        }

        protected virtual void TextBox_Validating(object? sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                if (Parameter.IsOptional)
                {
                    errorProvider.SetError(measureUnitLbl, null);
                    return;
                }
                else
                {
                    errorProvider.SetError(measureUnitLbl, "Значение не может быть пустым");
                    e.Cancel = true;
                    return;
                }
            }

            (bool parsed, double _, string? errorMessage) = Parameter
                .TrySetValue(textBox.Text);

            if (parsed)
            {
                errorProvider.SetError(measureUnitLbl, null);
                return;
            }

            errorProvider.SetError(measureUnitLbl, errorMessage);
            e.Cancel = true;
        }

        public virtual string Value
        {
            get => textBox.Text;
            set
            {
                textBox.Text = value;
            }
        }

        public virtual string DisplayedName
        {
            get => Parameter?.DisplayedName ?? string.Empty;
            set
            {
                Parameter.DisplayedName = value;

                paramNameLbl.Text = value;
            }
        }

        public virtual string NameInMathModel
        {
            get => Parameter?.NameInMathModel ?? string.Empty;
            set
            {
                Parameter.NameInMathModel = value;
            }
        }

        public virtual string MeasureUnit
        {
            get => Parameter?.MeasureUnit ?? string.Empty;
            set
            {
                Parameter.MeasureUnit = value;

                measureUnitLbl.Text = value;
            }
        }

        private Parameter parameter = new();
        [Browsable(false)]
        [ReadOnly(true)]
        public virtual Parameter Parameter
        {
            get => parameter;
            set
            {
                parameter = value;
                Refresh();
            }
        }
    }

}