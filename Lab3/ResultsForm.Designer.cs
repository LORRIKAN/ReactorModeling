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
            this.ea = new CustomFormsElements.ParameterOutput();
            this.q = new CustomFormsElements.ParameterOutput();
            this.N = new CustomFormsElements.ParameterOutput();
            this.deltaT = new CustomFormsElements.ParameterOutput();
            this.M = new CustomFormsElements.ParameterOutput();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mem = new CustomFormsElements.ParameterOutput();
            this.e = new CustomFormsElements.ParameterOutput();
            this.tCalc = new CustomFormsElements.ParameterOutput();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.deltaX = new CustomFormsElements.ParameterOutput();
            this.CCmax = new CustomFormsElements.ParameterOutput();
            this.k2 = new CustomFormsElements.ParameterOutput();
            this.k1 = new CustomFormsElements.ParameterOutput();
            this.u = new CustomFormsElements.ParameterOutput();
            this.S = new CustomFormsElements.ParameterOutput();
            this.tauR = new CustomFormsElements.ParameterOutput();
            this.teta = new CustomFormsElements.ParameterOutput();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 675);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.ea, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.q, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.N, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.deltaT, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.M, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(427, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(415, 667);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // ea
            // 
            this.ea.DisplayedName = "Абсолютная погрешность расчета концентрации целевого продукта";
            this.ea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ea.Location = new System.Drawing.Point(5, 441);
            this.ea.Margin = new System.Windows.Forms.Padding(5);
            this.ea.MeasureUnit = "моль/л";
            this.ea.Name = "ea";
            this.ea.NameInMathModel = "ea";
            this.ea.Size = new System.Drawing.Size(405, 221);
            this.ea.TabIndex = 10;
            this.ea.Value = "";
            // 
            // q
            // 
            this.q.DisplayedName = "Число делений шагов сетки пополам";
            this.q.Dock = System.Windows.Forms.DockStyle.Fill;
            this.q.Location = new System.Drawing.Point(5, 313);
            this.q.Margin = new System.Windows.Forms.Padding(5);
            this.q.MeasureUnit = "-";
            this.q.Name = "q";
            this.q.NameInMathModel = "q";
            this.q.Size = new System.Drawing.Size(405, 118);
            this.q.TabIndex = 9;
            this.q.Value = "";
            // 
            // N
            // 
            this.N.DisplayedName = "Число шагов сетки по времени";
            this.N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.N.Location = new System.Drawing.Point(5, 223);
            this.N.Margin = new System.Windows.Forms.Padding(5);
            this.N.MeasureUnit = "-";
            this.N.Name = "N";
            this.N.NameInMathModel = "N";
            this.N.Size = new System.Drawing.Size(405, 80);
            this.N.TabIndex = 8;
            this.N.Value = "";
            // 
            // deltaT
            // 
            this.deltaT.DisplayedName = "Шаг сетки по времени";
            this.deltaT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaT.Location = new System.Drawing.Point(5, 5);
            this.deltaT.Margin = new System.Windows.Forms.Padding(5);
            this.deltaT.MeasureUnit = "мин";
            this.deltaT.Name = "deltaT";
            this.deltaT.NameInMathModel = "deltaT";
            this.deltaT.Size = new System.Drawing.Size(405, 80);
            this.deltaT.TabIndex = 6;
            this.deltaT.Value = "";
            // 
            // M
            // 
            this.M.DisplayedName = "Число шагов сетки по длине реактора";
            this.M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.M.Location = new System.Drawing.Point(5, 95);
            this.M.Margin = new System.Windows.Forms.Padding(5);
            this.M.MeasureUnit = "-";
            this.M.Name = "M";
            this.M.NameInMathModel = "M";
            this.M.Size = new System.Drawing.Size(405, 118);
            this.M.TabIndex = 7;
            this.M.Value = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.mem, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.e, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tCalc, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tauR, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.teta, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(850, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(416, 667);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // mem
            // 
            this.mem.DisplayedName = "Занимаемая оперативная память";
            this.mem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mem.Location = new System.Drawing.Point(5, 445);
            this.mem.Margin = new System.Windows.Forms.Padding(5);
            this.mem.MeasureUnit = "Мб";
            this.mem.Name = "mem";
            this.mem.NameInMathModel = "mem";
            this.mem.Size = new System.Drawing.Size(406, 217);
            this.mem.TabIndex = 14;
            this.mem.Value = "";
            // 
            // e
            // 
            this.e.DisplayedName = "Приведенная погрешность расчета концентрации целевого продукта";
            this.e.Dock = System.Windows.Forms.DockStyle.Fill;
            this.e.Location = new System.Drawing.Point(5, 5);
            this.e.Margin = new System.Windows.Forms.Padding(5);
            this.e.MeasureUnit = "%";
            this.e.Name = "e";
            this.e.NameInMathModel = "e";
            this.e.Size = new System.Drawing.Size(406, 120);
            this.e.TabIndex = 12;
            this.e.Value = "";
            // 
            // tCalc
            // 
            this.tCalc.DisplayedName = "Время счёта";
            this.tCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCalc.Location = new System.Drawing.Point(5, 355);
            this.tCalc.Margin = new System.Windows.Forms.Padding(5);
            this.tCalc.MeasureUnit = "с";
            this.tCalc.Name = "tCalc";
            this.tCalc.NameInMathModel = "tCalc";
            this.tCalc.Size = new System.Drawing.Size(406, 80);
            this.tCalc.TabIndex = 13;
            this.tCalc.Value = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.deltaX, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CCmax, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.k2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.k1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.u, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.S, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(415, 667);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // deltaX
            // 
            this.deltaX.DisplayedName = "Шаг сетки по длине реактора";
            this.deltaX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaX.Location = new System.Drawing.Point(5, 531);
            this.deltaX.Margin = new System.Windows.Forms.Padding(5);
            this.deltaX.MeasureUnit = "м";
            this.deltaX.Name = "deltaX";
            this.deltaX.NameInMathModel = "deltaX";
            this.deltaX.Size = new System.Drawing.Size(405, 131);
            this.deltaX.TabIndex = 5;
            this.deltaX.Value = "";
            // 
            // CCmax
            // 
            this.CCmax.DisplayedName = "Максимальная концентрация целевого продукта в смеси";
            this.CCmax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CCmax.Location = new System.Drawing.Point(5, 403);
            this.CCmax.Margin = new System.Windows.Forms.Padding(5);
            this.CCmax.MeasureUnit = "моль/л";
            this.CCmax.Name = "CCmax";
            this.CCmax.NameInMathModel = "CCmax";
            this.CCmax.Size = new System.Drawing.Size(405, 118);
            this.CCmax.TabIndex = 4;
            this.CCmax.Value = "";
            // 
            // k2
            // 
            this.k2.DisplayedName = "Константа скорости 2-й реакции";
            this.k2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k2.Location = new System.Drawing.Point(5, 313);
            this.k2.Margin = new System.Windows.Forms.Padding(5);
            this.k2.MeasureUnit = "1/мин";
            this.k2.Name = "k2";
            this.k2.NameInMathModel = "k1";
            this.k2.Size = new System.Drawing.Size(405, 80);
            this.k2.TabIndex = 3;
            this.k2.Value = "";
            // 
            // k1
            // 
            this.k1.DisplayedName = "Константа скорости 1-й реакции";
            this.k1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k1.Location = new System.Drawing.Point(5, 223);
            this.k1.Margin = new System.Windows.Forms.Padding(5);
            this.k1.MeasureUnit = "л/(мольмин)";
            this.k1.Name = "k1";
            this.k1.NameInMathModel = "k1";
            this.k1.Size = new System.Drawing.Size(405, 80);
            this.k1.TabIndex = 2;
            this.k1.Value = "";
            // 
            // u
            // 
            this.u.DisplayedName = "Средняя линейная скорость потока";
            this.u.Dock = System.Windows.Forms.DockStyle.Fill;
            this.u.Location = new System.Drawing.Point(5, 133);
            this.u.Margin = new System.Windows.Forms.Padding(5);
            this.u.MeasureUnit = "м/мин";
            this.u.Name = "u";
            this.u.NameInMathModel = "u";
            this.u.Size = new System.Drawing.Size(405, 80);
            this.u.TabIndex = 1;
            this.u.Value = "";
            // 
            // S
            // 
            this.S.DisplayedName = "Площадь поперечного сечения реактора ";
            this.S.Dock = System.Windows.Forms.DockStyle.Fill;
            this.S.Location = new System.Drawing.Point(5, 5);
            this.S.Margin = new System.Windows.Forms.Padding(5);
            this.S.MeasureUnit = "м²";
            this.S.Name = "S";
            this.S.NameInMathModel = "S";
            this.S.Size = new System.Drawing.Size(405, 118);
            this.S.TabIndex = 0;
            this.S.Value = "";
            // 
            // tauR
            // 
            this.tauR.DisplayedName = "Среднее время пребывания смеси в реакторе";
            this.tauR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tauR.Location = new System.Drawing.Point(4, 134);
            this.tauR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tauR.MeasureUnit = "мин";
            this.tauR.Name = "tauR";
            this.tauR.NameInMathModel = "tauR";
            this.tauR.Size = new System.Drawing.Size(408, 122);
            this.tauR.TabIndex = 15;
            this.tauR.Value = "";
            // 
            // teta
            // 
            this.teta.DisplayedName = "Время моделирования объекта";
            this.teta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teta.Location = new System.Drawing.Point(4, 264);
            this.teta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.teta.MeasureUnit = "мин";
            this.teta.Name = "teta";
            this.teta.NameInMathModel = "teta";
            this.teta.Size = new System.Drawing.Size(408, 82);
            this.teta.TabIndex = 16;
            this.teta.Value = "";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 675);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultsForm";
            this.Text = "Результаты";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CustomFormsElements.ParameterOutput ea;
        private CustomFormsElements.ParameterOutput q;
        private CustomFormsElements.ParameterOutput N;
        private CustomFormsElements.ParameterOutput deltaT;
        private CustomFormsElements.ParameterOutput M;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CustomFormsElements.ParameterOutput mem;
        private CustomFormsElements.ParameterOutput e;
        private CustomFormsElements.ParameterOutput tCalc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomFormsElements.ParameterOutput deltaX;
        private CustomFormsElements.ParameterOutput CCmax;
        private CustomFormsElements.ParameterOutput k2;
        private CustomFormsElements.ParameterOutput k1;
        private CustomFormsElements.ParameterOutput u;
        private CustomFormsElements.ParameterOutput S;
        private CustomFormsElements.ParameterOutput tauR;
        private CustomFormsElements.ParameterOutput teta;
    }
}