namespace Researcher
{
    partial class ResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.deltaT = new CustomFormsElements.ParameterOutput();
            this.deltaX = new CustomFormsElements.ParameterOutput();
            this.e = new CustomFormsElements.ParameterOutput();
            this.ea = new CustomFormsElements.ParameterOutput();
            this.q = new CustomFormsElements.ParameterOutput();
            this.N = new CustomFormsElements.ParameterOutput();
            this.M = new CustomFormsElements.ParameterOutput();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mem = new CustomFormsElements.ParameterOutput();
            this.tCalc = new CustomFormsElements.ParameterOutput();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tauR = new CustomFormsElements.ParameterOutput();
            this.S = new CustomFormsElements.ParameterOutput();
            this.CCmax = new CustomFormsElements.ParameterOutput();
            this.k2 = new CustomFormsElements.ParameterOutput();
            this.k1 = new CustomFormsElements.ParameterOutput();
            this.u = new CustomFormsElements.ParameterOutput();
            this.label1 = new System.Windows.Forms.Label();
            this.teta = new CustomFormsElements.ParameterOutput();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1243, 635);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.deltaT, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.deltaX, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.e, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.ea, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.q, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.N, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.M, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(418, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(407, 627);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // deltaT
            // 
            this.deltaT.DisplayedName = "Шаг сетки по времени";
            this.deltaT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaT.Location = new System.Drawing.Point(4, 554);
            this.deltaT.Margin = new System.Windows.Forms.Padding(4);
            this.deltaT.MeasureUnit = "мин";
            this.deltaT.Name = "deltaT";
            this.deltaT.NameInMathModel = "deltaT";
            this.deltaT.Size = new System.Drawing.Size(399, 69);
            this.deltaT.TabIndex = 21;
            this.deltaT.Value = "";
            // 
            // deltaX
            // 
            this.deltaX.DisplayedName = "Шаг сетки по длине реактора";
            this.deltaX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaX.Location = new System.Drawing.Point(4, 484);
            this.deltaX.Margin = new System.Windows.Forms.Padding(4);
            this.deltaX.MeasureUnit = "м";
            this.deltaX.Name = "deltaX";
            this.deltaX.NameInMathModel = "deltaX";
            this.deltaX.Size = new System.Drawing.Size(399, 62);
            this.deltaX.TabIndex = 20;
            this.deltaX.Value = "";
            // 
            // e
            // 
            this.e.DisplayedName = "Приведенная погрешность расчета концентрации целевого продукта";
            this.e.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e.Location = new System.Drawing.Point(4, 384);
            this.e.Margin = new System.Windows.Forms.Padding(4);
            this.e.MeasureUnit = "%";
            this.e.Name = "e";
            this.e.NameInMathModel = "e";
            this.e.Size = new System.Drawing.Size(399, 92);
            this.e.TabIndex = 19;
            this.e.Value = "";
            // 
            // ea
            // 
            this.ea.DisplayedName = "Абсолютная погрешность расчета концентрации целевого продукта";
            this.ea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ea.Location = new System.Drawing.Point(4, 284);
            this.ea.Margin = new System.Windows.Forms.Padding(4);
            this.ea.MeasureUnit = "моль/л";
            this.ea.Name = "ea";
            this.ea.NameInMathModel = "ea";
            this.ea.Size = new System.Drawing.Size(399, 92);
            this.ea.TabIndex = 10;
            this.ea.Value = "";
            // 
            // q
            // 
            this.q.DisplayedName = "Число делений шагов сетки пополам";
            this.q.Dock = System.Windows.Forms.DockStyle.Fill;
            this.q.Location = new System.Drawing.Point(4, 214);
            this.q.Margin = new System.Windows.Forms.Padding(4);
            this.q.MeasureUnit = "-";
            this.q.Name = "q";
            this.q.NameInMathModel = "q";
            this.q.Size = new System.Drawing.Size(399, 62);
            this.q.TabIndex = 9;
            this.q.Value = "";
            // 
            // N
            // 
            this.N.DisplayedName = "Число шагов сетки по времени";
            this.N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.N.Location = new System.Drawing.Point(4, 144);
            this.N.Margin = new System.Windows.Forms.Padding(4);
            this.N.MeasureUnit = "-";
            this.N.Name = "N";
            this.N.NameInMathModel = "N";
            this.N.Size = new System.Drawing.Size(399, 62);
            this.N.TabIndex = 8;
            this.N.Value = "";
            // 
            // M
            // 
            this.M.DisplayedName = "Число шагов сетки по длине реактора";
            this.M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M.Location = new System.Drawing.Point(4, 74);
            this.M.Margin = new System.Windows.Forms.Padding(4);
            this.M.MeasureUnit = "-";
            this.M.Name = "M";
            this.M.NameInMathModel = "M";
            this.M.Size = new System.Drawing.Size(399, 62);
            this.M.TabIndex = 7;
            this.M.Value = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 70);
            this.label2.TabIndex = 11;
            this.label2.Text = "Параметры метода решения";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.mem, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tCalc, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(832, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(407, 627);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // mem
            // 
            this.mem.DisplayedName = "Занимаемая оперативная память";
            this.mem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mem.Location = new System.Drawing.Point(4, 144);
            this.mem.Margin = new System.Windows.Forms.Padding(4);
            this.mem.MeasureUnit = "Мб";
            this.mem.Name = "mem";
            this.mem.NameInMathModel = "mem";
            this.mem.Size = new System.Drawing.Size(399, 479);
            this.mem.TabIndex = 16;
            this.mem.Value = "";
            // 
            // tCalc
            // 
            this.tCalc.DisplayedName = "Время счёта";
            this.tCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCalc.Location = new System.Drawing.Point(4, 74);
            this.tCalc.Margin = new System.Windows.Forms.Padding(4);
            this.tCalc.MeasureUnit = "с";
            this.tCalc.Name = "tCalc";
            this.tCalc.NameInMathModel = "tCalc";
            this.tCalc.Size = new System.Drawing.Size(399, 62);
            this.tCalc.TabIndex = 15;
            this.tCalc.Value = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 70);
            this.label3.TabIndex = 0;
            this.label3.Text = "Показатели экономичности";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tauR, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.S, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CCmax, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.k2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.k1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.u, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.teta, 0, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(407, 627);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tauR
            // 
            this.tauR.DisplayedName = "Среднее время пребывания смеси в реакторе";
            this.tauR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tauR.Location = new System.Drawing.Point(3, 453);
            this.tauR.MeasureUnit = "мин";
            this.tauR.Name = "tauR";
            this.tauR.NameInMathModel = "tauR";
            this.tauR.Size = new System.Drawing.Size(401, 64);
            this.tauR.TabIndex = 17;
            this.tauR.Value = "";
            // 
            // S
            // 
            this.S.DisplayedName = "Площадь поперечного сечения реактора ";
            this.S.Dock = System.Windows.Forms.DockStyle.Fill;
            this.S.Location = new System.Drawing.Point(4, 384);
            this.S.Margin = new System.Windows.Forms.Padding(4);
            this.S.MeasureUnit = "м²";
            this.S.Name = "S";
            this.S.NameInMathModel = "S";
            this.S.Size = new System.Drawing.Size(399, 62);
            this.S.TabIndex = 5;
            this.S.Value = "";
            // 
            // CCmax
            // 
            this.CCmax.DisplayedName = "Максимальная концентрация целевого продукта в смеси";
            this.CCmax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CCmax.Location = new System.Drawing.Point(4, 284);
            this.CCmax.Margin = new System.Windows.Forms.Padding(4);
            this.CCmax.MeasureUnit = "моль/л";
            this.CCmax.Name = "CCmax";
            this.CCmax.NameInMathModel = "CCmax";
            this.CCmax.Size = new System.Drawing.Size(399, 92);
            this.CCmax.TabIndex = 4;
            this.CCmax.Value = "";
            // 
            // k2
            // 
            this.k2.DisplayedName = "Константа скорости 2-й реакции";
            this.k2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k2.Location = new System.Drawing.Point(4, 214);
            this.k2.Margin = new System.Windows.Forms.Padding(4);
            this.k2.MeasureUnit = "1/мин";
            this.k2.Name = "k2";
            this.k2.NameInMathModel = "k1";
            this.k2.Size = new System.Drawing.Size(399, 62);
            this.k2.TabIndex = 3;
            this.k2.Value = "";
            // 
            // k1
            // 
            this.k1.DisplayedName = "Константа скорости 1-й реакции";
            this.k1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k1.Location = new System.Drawing.Point(4, 144);
            this.k1.Margin = new System.Windows.Forms.Padding(4);
            this.k1.MeasureUnit = "л/(мольмин)";
            this.k1.Name = "k1";
            this.k1.NameInMathModel = "k1";
            this.k1.Size = new System.Drawing.Size(399, 62);
            this.k1.TabIndex = 2;
            this.k1.Value = "";
            // 
            // u
            // 
            this.u.DisplayedName = "Средняя линейная скорость потока";
            this.u.Dock = System.Windows.Forms.DockStyle.Fill;
            this.u.Location = new System.Drawing.Point(4, 74);
            this.u.Margin = new System.Windows.Forms.Padding(4);
            this.u.MeasureUnit = "м/мин";
            this.u.Name = "u";
            this.u.NameInMathModel = "u";
            this.u.Size = new System.Drawing.Size(399, 62);
            this.u.TabIndex = 1;
            this.u.Value = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 70);
            this.label1.TabIndex = 6;
            this.label1.Text = "Технологические параметры процесса";
            // 
            // teta
            // 
            this.teta.DisplayedName = "Время моделирования объекта";
            this.teta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teta.Location = new System.Drawing.Point(3, 523);
            this.teta.MeasureUnit = "мин";
            this.teta.Name = "teta";
            this.teta.NameInMathModel = "teta";
            this.teta.Size = new System.Drawing.Size(401, 101);
            this.teta.TabIndex = 18;
            this.teta.Value = "";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 635);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResultsForm";
            this.Text = "Результаты";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CustomFormsElements.ParameterOutput ea;
        private CustomFormsElements.ParameterOutput q;
        private CustomFormsElements.ParameterOutput N;
        private CustomFormsElements.ParameterOutput M;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomFormsElements.ParameterOutput CCmax;
        private CustomFormsElements.ParameterOutput k2;
        private CustomFormsElements.ParameterOutput k1;
        private CustomFormsElements.ParameterOutput u;
        private CustomFormsElements.ParameterOutput S;
        private System.Windows.Forms.Label label1;
        private CustomFormsElements.ParameterOutput tauR;
        private CustomFormsElements.ParameterOutput teta;
        private System.Windows.Forms.Label label2;
        private CustomFormsElements.ParameterOutput e;
        private CustomFormsElements.ParameterOutput deltaX;
        private CustomFormsElements.ParameterOutput deltaT;
        private System.Windows.Forms.Label label3;
        private CustomFormsElements.ParameterOutput tCalc;
        private CustomFormsElements.ParameterOutput mem;
    }
}