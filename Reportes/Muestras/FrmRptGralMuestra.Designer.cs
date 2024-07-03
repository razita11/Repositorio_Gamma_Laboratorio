namespace ProyectoLaboratorio.Reportes.Muestras
{
    partial class FrmRptGralMuestra
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
            this.CrvGralMuestra = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvGralMuestra
            // 
            this.CrvGralMuestra.ActiveViewIndex = -1;
            this.CrvGralMuestra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvGralMuestra.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvGralMuestra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvGralMuestra.Location = new System.Drawing.Point(0, 0);
            this.CrvGralMuestra.Name = "CrvGralMuestra";
            this.CrvGralMuestra.Size = new System.Drawing.Size(800, 450);
            this.CrvGralMuestra.TabIndex = 0;
            this.CrvGralMuestra.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrvGralMuestra.Load += new System.EventHandler(this.CrvGralMuestra_Load);
            // 
            // FrmRptGralMuestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrvGralMuestra);
            this.Name = "FrmRptGralMuestra";
            this.Text = "FrmRptGralMuestra";
            this.Load += new System.EventHandler(this.FrmRptGralMuestra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrvGralMuestra;
    }
}