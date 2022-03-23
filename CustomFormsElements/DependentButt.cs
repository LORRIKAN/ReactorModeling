using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CustomFormsElements
{
    public class DependentButt : Button
    {
        public DependentButt()
        {
            Enabled = false;
        }

        public void AddMasterControlsRange(params Control[] controls)
        {
            foreach (var item in controls)
            {
                AddMasterControl(item);
            }
        }

        public void AddMasterControl(Control control)
        {
            control.Validating += Control_Validating;
            control.Validated += Control_Validated;

            bool validated = false;

            if (control is ContainerControl containerControl)
                validated = containerControl.ValidateChildren();

            MasterControls.TryAdd(control, validated);

            if (EnableControlsCheck)
                TryEnable();
        }

        public void RemoveMasterControl(Control control)
        {
            control.Validating -= Control_Validating;
            control.Validated -= Control_Validated;
            MasterControls.Remove(control);

            if (EnableControlsCheck)
                TryEnable();
        }

        private void Control_Validating(object sender, CancelEventArgs e)
        {
            if (sender is not Control control)
                return;

            MasterControls[control] = false;

            Enabled = false;
        }

        private void Control_Validated(object sender, EventArgs e)
        {
            if (sender is not Control control)
                return;

            MasterControls[control] = true;

            if (EnableControlsCheck)
                TryEnable();
        }

        private Dictionary<Control, bool> MasterControls { get; } = new();

        private bool EnableControlsCheck { get; set; } = true;

        public void TryEnable()
        {
            EnableControlsCheck = true;
            Enabled = MasterControls.All(p => p.Value is true);
        }

        public void Disable()
        {
            Enabled = false;
            EnableControlsCheck = false;
        }
    }
}
