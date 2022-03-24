using Model;
using CustomFormsElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Researcher
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        public IEnumerable<Parameter> Results { get; set; }

        protected override void OnShown(EventArgs e)
        {
            SetMemoryUsage();
            SetParamsValues();

            base.OnShown(e);
        }

        private void SetParamsValues()
        {
            foreach (ParameterOutput parameterO in this.GetChildControlsOfType<ParameterOutput>())
            {
                if (Results.FirstOrDefault(p => p.NameInMathModel == parameterO.NameInMathModel)
                    is Parameter param)
                    parameterO.Value = param.ToStringWithPrecision();
            }
        }

        private void SetMemoryUsage()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);

                    Process currentProcess = Process.GetCurrentProcess();

                    long usedMemory = currentProcess.PrivateMemorySize64;

                    Invoke(() => mem.Value = (usedMemory / (1024 * 1024)).ToString());
                }
            });
        }
    }
}
