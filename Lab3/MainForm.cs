using CustomFormsElements;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Researcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            startCalcsButt.AddMasterControlsRange(this.GetChildControlsOfType<ParameterInput>().ToArray());
        }

        private void SwitchControls(bool enabled)
        {
            if (enabled)
                startCalcsButt.TryEnable();
            else
                startCalcsButt.Disable();
        }

        private void startCalcsButt_Click(object sender, EventArgs e)
        {
            SwitchControls(false);


        }
    }
}
