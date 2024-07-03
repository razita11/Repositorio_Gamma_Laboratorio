namespace ProyectoLaboratorio.Vistas
{
    partial class FrmBuscarMascota
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
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.DCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DcEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(146, 60);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(625, 27);
            this.TxtBuscar.TabIndex = 79;
            this.TxtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscar_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 78;
            this.label1.Text = "Buscar:";
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.AllowUserToDeleteRows = false;
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DCId,
            this.DCNombre,
            this.DCEspecie,
            this.DcEdad});
            this.DgvData.Location = new System.Drawing.Point(48, 93);
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.Size = new System.Drawing.Size(723, 298);
            this.DgvData.TabIndex = 77;
            this.DgvData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvData_CellContentDoubleClick);
            // 
            // DCId
            // 
            this.DCId.HeaderText = "ID";
            this.DCId.Name = "DCId";
            this.DCId.ReadOnly = true;
            this.DCId.Width = 150;
            // 
            // DCNombre
            // 
            this.DCNombre.HeaderText = "Nombre";
            this.DCNombre.Name = "DCNombre";
            this.DCNombre.ReadOnly = true;
            this.DCNombre.Width = 200;
            // 
            // DCEspecie
            // 
            this.DCEspecie.HeaderText = "Especie";
            this.DCEspecie.Name = "DCEspecie";
            this.DCEspecie.ReadOnly = true;
            this.DCEspecie.Width = 200;
            // 
            // DcEdad
            // 
            this.DcEdad.HeaderText = "Edad";
            this.DcEdad.Name = "DcEdad";
            this.DcEdad.ReadOnly = true;
            // 
            // FrmBuscarMascota
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvData);
            this.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBuscarMascota";
            this.Text = "FrmBuscarMascota";
            this.Load += new System.EventHandler(this.FrmBuscarMascota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn DcEdad;
    }
}