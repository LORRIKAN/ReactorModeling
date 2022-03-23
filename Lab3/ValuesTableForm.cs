using System;
using System.Windows.Forms;

namespace Researcher
{
    public partial class ValuesTableForm : Form
    {
        public ValuesTableForm()
        {
            InitializeComponent();
            rebuildTable.AddMasterControlsRange(deltaTmult, deltaXmult);
            rebuildTable.Click += (_, _) => BuildTable();
        }

        private string componentName;

        public string ComponentName { get => componentName; 
            set
            {
                componentName = value;
                groupBox1.Text = $"Таблица значений концентрации " +
                $"компонента {componentName} по времени и координате";
            }
        }

        public int DeltaTMult { get => (int)deltaTmult.Parameter.Value; set => deltaTmult.Parameter.Value = value; }

        public int DeltaXMult { get => (int)deltaXmult.Parameter.Value; set => deltaXmult.Parameter.Value = value; }

        public double DeltaT { get; set; }

        public double DeltaX { get; set; }

        public double[][] Values { get; set; }

        protected override void OnShown(EventArgs e)
        {
            BuildTable();
            base.OnShown(e);
        }

        private void BuildTable()
        {
            int deltaTMult = DeltaTMult;
            int deltaXMult = DeltaXMult;

            for (int j = 0; j < Values.Length; j += deltaTMult)
                dataGridView.Columns.Add(j.ToString(), (DeltaT * j).ToString($"F{2}"));

            for (int i = 0; i < Values[0].Length; i += deltaXMult)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = (DeltaX * i).ToString($"F{2}");

                dataGridView.Rows.Add(row);
            }

            for (int j = 0; j < Values.Length; j += deltaTMult)
                for (int i = 0; i < Values[j].Length; j += deltaXMult)
                    dataGridView[j, i].Value = Values[j][i];
        }
    }
}
