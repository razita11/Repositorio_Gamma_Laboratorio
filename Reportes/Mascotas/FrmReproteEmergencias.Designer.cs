namespace ProyectoLaboratorio.Reportes.Mascotas
{
    partial class FrmReproteEmergencias
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
            this.CrvReporGralEmer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvReporGralEmer
            // 
            this.CrvReporGralEmer.ActiveViewIndex = -1;
            this.CrvReporGralEmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvReporGralEmer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvReporGralEmer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvReporGralEmer.Location = new System.Drawing.Point(0, 0);
            this.CrvReporGralEmer.Name = "CrvReporGralEmer";
            this.CrvReporGralEmer.Size = new System.Drawing.Size(800, 450);
            this.CrvReporGralEmer.TabIndex = 0;
            this.CrvReporGralEmer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmReproteEmergencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrvReporGralEmer);
            this.Name = "FrmReproteEmergencias";
            this.Text = "FrmReproteEmergencias";
            this.Load += new System.EventHandler(this.FrmReproteEmergencias_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvReporGralEmer;
    }
}