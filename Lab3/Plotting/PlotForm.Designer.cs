namespace Researcher.Plotting
{
    partial class PlotForm
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
            this.plot = new CustomFormsElements.Plot();
            this.SuspendLayout();
            // 
            // plot
            // 
            this.plot.BackColor = System.Drawing.Color.Transparent;
            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(0, 0);
            this.plot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(800, 450);
            this.plot.TabIndex = 0;
            this.plot.Title = null;
            this.plot.XLabel = null;
            this.plot.YLabel = null;
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plot);
            this.Name = "PlotForm";
            this.Text = "График";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomFormsElements.Plot plot;
    }
}