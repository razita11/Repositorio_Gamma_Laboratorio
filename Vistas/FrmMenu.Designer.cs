namespace ProyectoLaboratorio.Vistas
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnAcercaDe = new System.Windows.Forms.Button();
            this.BtnProveedores = new System.Windows.Forms.Button();
            this.BtnInventario = new System.Windows.Forms.Button();
            this.BtnVenta = new System.Windows.Forms.Button();
            this.BtnPruebas = new System.Windows.Forms.Button();
            this.BtnMuestras = new System.Windows.Forms.Button();
            this.BtnPacientes = new System.Windows.Forms.Button();
            this.BtnCitas = new System.Windows.Forms.Button();
            this.BtnUsuarios = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gamma Laboratorios | Menú";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 71);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Menú | Gamma Laboratorios ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAcercaDe);
            this.panel2.Controls.Add(this.BtnProveedores);
            this.panel2.Controls.Add(this.BtnInventario);
            this.panel2.Controls.Add(this.BtnVenta);
            this.panel2.Controls.Add(this.BtnPruebas);
            this.panel2.Controls.Add(this.BtnMuestras);
            this.panel2.Controls.Add(this.BtnPacientes);
            this.panel2.Controls.Add(this.BtnCitas);
            this.panel2.Controls.Add(this.BtnUsuarios);
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 80);
            this.panel2.TabIndex = 8;
            // 
            // BtnAcercaDe
            // 
            this.BtnAcercaDe.BackColor = System.Drawing.Color.White;
            this.BtnAcercaDe.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("BtnAcercaDe.Image")));
            this.BtnAcercaDe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAcercaDe.Location = new System.Drawing.Point(869, 3);
            this.BtnAcercaDe.Name = "BtnAcercaDe";
            this.BtnAcercaDe.Size = new System.Drawing.Size(99, 74);
            this.BtnAcercaDe.TabIndex = 9;
            this.BtnAcercaDe.Text = "Acerca De";
            this.BtnAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAcercaDe.UseVisualStyleBackColor = false;
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.BackColor = System.Drawing.Color.White;
            this.BtnProveedores.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("BtnProveedores.Image")));
            this.BtnProveedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnProveedores.Location = new System.Drawing.Point(743, 3);
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(120, 74);
            this.BtnProveedores.TabIndex = 8;
            this.BtnProveedores.Text = "Proveedores";
            this.BtnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnProveedores.UseVisualStyleBackColor = false;
            this.BtnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // BtnInventario
            // 
            this.BtnInventario.BackColor = System.Drawing.Color.White;
            this.BtnInventario.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInventario.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventario.Image")));
            this.BtnInventario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnInventario.Location = new System.Drawing.Point(533, 3);
            this.BtnInventario.Name = "BtnInventario";
            this.BtnInventario.Size = new System.Drawing.Size(99, 74);
            this.BtnInventario.TabIndex = 7;
            this.BtnInventario.Text = "Inventario";
            this.BtnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnInventario.UseVisualStyleBackColor = false;
            this.BtnInventario.Click += new System.EventHandler(this.BtnInventario_Click);
            // 
            // BtnVenta
            // 
            this.BtnVenta.BackColor = System.Drawing.Color.White;
            this.BtnVenta.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVenta.Image = ((System.Drawing.Image)(resources.GetObject("BtnVenta.Image")));
            this.BtnVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnVenta.Location = new System.Drawing.Point(638, 3);
            this.BtnVenta.Name = "BtnVenta";
            this.BtnVenta.Size = new System.Drawing.Size(99, 74);
            this.BtnVenta.TabIndex = 6;
            this.BtnVenta.Text = "Venta";
            this.BtnVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnVenta.UseVisualStyleBackColor = false;
            this.BtnVenta.Click += new System.EventHandler(this.BtnVenta_Click);
            // 
            // BtnPruebas
            // 
            this.BtnPruebas.BackColor = System.Drawing.Color.White;
            this.BtnPruebas.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPruebas.Image = ((System.Drawing.Image)(resources.GetObject("BtnPruebas.Image")));
            this.BtnPruebas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPruebas.Location = new System.Drawing.Point(428, 3);
            this.BtnPruebas.Name = "BtnPruebas";
            this.BtnPruebas.Size = new System.Drawing.Size(99, 74);
            this.BtnPruebas.TabIndex = 5;
            this.BtnPruebas.Text = "Pruebas";
            this.BtnPruebas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnPruebas.UseVisualStyleBackColor = false;
            this.BtnPruebas.Click += new System.EventHandler(this.BtnPruebas_Click);
            // 
            // BtnMuestras
            // 
            this.BtnMuestras.BackColor = System.Drawing.Color.White;
            this.BtnMuestras.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMuestras.Image = ((System.Drawing.Image)(resources.GetObject("BtnMuestras.Image")));
            this.BtnMuestras.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnMuestras.Location = new System.Drawing.Point(323, 3);
            this.BtnMuestras.Name = "BtnMuestras";
            this.BtnMuestras.Size = new System.Drawing.Size(99, 74);
            this.BtnMuestras.TabIndex = 4;
            this.BtnMuestras.Text = "Muestras";
            this.BtnMuestras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnMuestras.UseVisualStyleBackColor = false;
            this.BtnMuestras.Click += new System.EventHandler(this.BtnMuestras_Click);
            // 
            // BtnPacientes
            // 
            this.BtnPacientes.BackColor = System.Drawing.Color.White;
            this.BtnPacientes.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPacientes.Image = ((System.Drawing.Image)(resources.GetObject("BtnPacientes.Image")));
            this.BtnPacientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPacientes.Location = new System.Drawing.Point(113, 3);
            this.BtnPacientes.Name = "BtnPacientes";
            this.BtnPacientes.Size = new System.Drawing.Size(99, 74);
            this.BtnPacientes.TabIndex = 3;
            this.BtnPacientes.Text = "Pacientes";
            this.BtnPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnPacientes.UseVisualStyleBackColor = false;
            this.BtnPacientes.Click += new System.EventHandler(this.BtnPacientes_Click);
            // 
            // BtnCitas
            // 
            this.BtnCitas.BackColor = System.Drawing.Color.White;
            this.BtnCitas.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCitas.Image = ((System.Drawing.Image)(resources.GetObject("BtnCitas.Image")));
            this.BtnCitas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCitas.Location = new System.Drawing.Point(218, 3);
            this.BtnCitas.Name = "BtnCitas";
            this.BtnCitas.Size = new System.Drawing.Size(99, 74);
            this.BtnCitas.TabIndex = 2;
            this.BtnCitas.Text = "Citas";
            this.BtnCitas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCitas.UseVisualStyleBackColor = false;
            this.BtnCitas.Click += new System.EventHandler(this.BtnCitas_Click);
            // 
            // BtnUsuarios
            // 
            this.BtnUsuarios.BackColor = System.Drawing.Color.White;
            this.BtnUsuarios.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("BtnUsuarios.Image")));
            this.BtnUsuarios.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnUsuarios.Location = new System.Drawing.Point(8, 3);
            this.BtnUsuarios.Name = "BtnUsuarios";
            this.BtnUsuarios.Size = new System.Drawing.Size(99, 74);
            this.BtnUsuarios.TabIndex = 1;
            this.BtnUsuarios.Text = "Usuarios";
            this.BtnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnUsuarios.UseVisualStyleBackColor = false;
            this.BtnUsuarios.Click += new System.EventHandler(this.BtnUsuarios_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(980, 505);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnUsuarios;
        private System.Windows.Forms.Button BtnAcercaDe;
        private System.Windows.Forms.Button BtnProveedores;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Button BtnVenta;
        private System.Windows.Forms.Button BtnPruebas;
        private System.Windows.Forms.Button BtnMuestras;
        private System.Windows.Forms.Button BtnPacientes;
        private System.Windows.Forms.Button BtnCitas;
    }
}