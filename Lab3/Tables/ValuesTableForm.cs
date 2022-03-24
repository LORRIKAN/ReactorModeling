using Model;
using System;
using System.Windows.Forms;

namespace Researcher.Tables
{
    public partial class ValuesTableForm : Form
    {
        public ValuesTableForm()
        {
            InitializeComponent();
            rebuildTable.AddMasterControlsRange(deltaTmult, deltaXmult);
            rebuildTable.Click += (_, _) => BuildTable();
        }

        private TableBuildMessage tableBuildMessage;

        public int DeltaTMult { get => (int)deltaTmult.Parameter.Value; set => deltaTmult.Parameter.Value = value; }

        public int DeltaXMult { get => (int)deltaXmult.Parameter.Value; set => deltaXmult.Parameter.Value = value; }

        public TableBuildMessage TableBuildMessage 
        { 
            get => tableBuildMessage;
            set 
            {
                tableBuildMessage = value;
                groupBox1.Text = $"Таблица значений концентрации " +
                $"компонента {value.ComponentName} по времени и координате";
            } 
        }

        private void BuildTable()
        {
            dataGridView.Columns.Clear();
            int deltaTMult = DeltaTMult;
            int deltaXMult = DeltaXMult;

            for (int j = 0; j < TableBuildMessage.Values.GetLength(0); j += deltaTMult)
                dataGridView.Columns.Add(j.ToString(), 
                    (TableBuildMessage.DeltaT * j)
                    .ToString($"F{TableBuildMessage.DeltaT.DecimalPlaces ?? 2}"));

            for (int i = 0; i < TableBuildMessage.Values[0].Length; i += deltaXMult)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = (TableBuildMessage.DeltaX * i)
                    .ToString($"F{TableBuildMessage.DeltaX.DecimalPlaces ?? 2}");

                dataGridView.Rows.Add(row);
            }

            for (int j = 0; j < TableBuildMessage.Values.GetLength(0); j += deltaTMult)
                for (int i = 0; i < TableBuildMessage.Values[j].Length; i += deltaXMult)
                    dataGridView[j / deltaTMult, i / deltaXMult].Value = 
                        TableBuildMessage.Values[j][i]
                        .ToString($"F{TableBuildMessage.ValuesDecimalPlaces ?? 2}");

            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
    }
}
