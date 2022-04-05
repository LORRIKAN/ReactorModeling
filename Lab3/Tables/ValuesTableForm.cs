using System.Windows.Forms;

namespace Researcher.Tables
{
    public partial class ValuesTableForm : Form
    {
        public ValuesTableForm()
        {
            InitializeComponent();
            buildTableButt.AddMasterControlsRange(deltaTmult, deltaXmult);
            buildTableButt.Click += (_, _) => BuildTable();

            deltaTmult.Parameter.ParseAndCheckConditions.CheckFuncs.Add((v) =>
            {
                if ((tableBuildMessage.Values.GetLength(0) - 1) % (int)v is not 0)
                    return (false, $"Значение должно быть делителем количества " +
                    $"строк ({tableBuildMessage.Values.GetLength(0) - 1}) нацело");

                return (true, null);
            });

            deltaXmult.Parameter.ParseAndCheckConditions.CheckFuncs.Add((v) =>
            {
                if ((tableBuildMessage.Values[0].Length - 1) % (int)v is not 0)
                    return (false, $"Значение должно быть делителем количества " +
                    $"столбцов ({tableBuildMessage.Values[0].Length - 1}) нацело");

                return (true, null);
            });
        }

        private TableBuildMessage tableBuildMessage;

        public int DeltaTMult { get => (int)deltaTmult.Parameter.Value; set => deltaTmult.Parameter.Value = value; }

        public int DeltaXMult { get => (int)deltaXmult.Parameter.Value; set => deltaXmult.Parameter.Value = value; }

        public string HLabel => label1.Text;

        public string VLabel => label2.Text;

        public DataGridView Data => dataGridView;

        public string TableName => groupBox1.Text;

        public TableBuildMessage TableBuildMessage
        {
            get => tableBuildMessage;
            set
            {
                tableBuildMessage = value;
                groupBox1.Text = $"Таблица значений концентрации " +
                $"компонента {value.ComponentName} по длине реактора и времени";
            }
        }

        public void BuildTable()
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
