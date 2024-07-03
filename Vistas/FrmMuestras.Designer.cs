namespace ProyectoLaboratorio.Vistas
{
    partial class FrmMuestras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMuestras));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtMuestra = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTemperatura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DtpFecha_reco = new System.Windows.Forms.DateTimePicker();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnBuscarDni = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.CmbMuestra = new System.Windows.Forms.ComboBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Muestras | Gamma Laboratorios ";
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
            this.panel2.Location = new System.Drawing.Point(1, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 80);
            this.panel2.TabIndex = 10;
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
            this.BtnMuestras.BackColor = System.Drawing.Color.Cyan;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 71);
            this.panel1.TabIndex = 9;
            // 
            // TxtMuestra
            // 
            this.TxtMuestra.Location = new System.Drawing.Point(9, 159);
            this.TxtMuestra.Name = "TxtMuestra";
            this.TxtMuestra.ReadOnly = true;
            this.TxtMuestra.Size = new System.Drawing.Size(116, 27);
            this.TxtMuestra.TabIndex = 11;
            this.TxtMuestra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtMuestra.TextChanged += new System.EventHandler(this.TxtMuestra_TextChanged);
            // 
            // TxtNombre
            // 
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.Location = new System.Drawing.Point(639, 192);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(315, 27);
            this.TxtNombre.TabIndex = 36;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(552, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 35;
            this.label4.Text = "Nombre:";
            // 
            // TxtDni
            // 
            this.TxtDni.Location = new System.Drawing.Point(130, 192);
            this.TxtDni.Name = "TxtDni";
            this.TxtDni.Size = new System.Drawing.Size(272, 27);
            this.TxtDni.TabIndex = 34;
            this.TxtDni.TextChanged += new System.EventHandler(this.TxtDni_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "DNI:";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.BackColor = System.Drawing.Color.White;
            this.TxtCodigo.Location = new System.Drawing.Point(130, 241);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(272, 27);
            this.TxtCodigo.TabIndex = 38;
            this.TxtCodigo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Codigo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(488, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 39;
            this.label5.Text = "Tipo de Muestra:";
            // 
            // TxtTemperatura
            // 
            this.TxtTemperatura.Location = new System.Drawing.Point(130, 297);
            this.TxtTemperatura.Name = "TxtTemperatura";
            this.TxtTemperatura.Size = new System.Drawing.Size(272, 27);
            this.TxtTemperatura.TabIndex = 43;
            this.TxtTemperatura.TextChanged += new System.EventHandler(this.TxtTemperatura_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Temperatura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(473, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Fecha Recolección:";
            // 
            // DtpFecha_reco
            // 
            this.DtpFecha_reco.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha_reco.Location = new System.Drawing.Point(639, 298);
            this.DtpFecha_reco.Name = "DtpFecha_reco";
            this.DtpFecha_reco.Size = new System.Drawing.Size(315, 27);
            this.DtpFecha_reco.TabIndex = 45;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.Red;
            this.BtnSalir.ForeColor = System.Drawing.Color.White;
            this.BtnSalir.Location = new System.Drawing.Point(818, 457);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(120, 36);
            this.BtnSalir.TabIndex = 49;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(377, 382);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(133, 58);
            this.BtnBuscar.TabIndex = 48;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.Location = new System.Drawing.Point(217, 382);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(133, 58);
            this.BtnCancelar.TabIndex = 47;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnRegistrar.Image")));
            this.BtnRegistrar.Location = new System.Drawing.Point(50, 382);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(133, 58);
            this.BtnRegistrar.TabIndex = 46;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(536, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 58);
            this.button1.TabIndex = 50;
            this.button1.Text = "Registrar P";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBuscarDni
            // 
            this.BtnBuscarDni.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarDni.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscarDni.Image")));
            this.BtnBuscarDni.Location = new System.Drawing.Point(408, 194);
            this.BtnBuscarDni.Name = "BtnBuscarDni";
            this.BtnBuscarDni.Size = new System.Drawing.Size(70, 25);
            this.BtnBuscarDni.TabIndex = 52;
            this.BtnBuscarDni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBuscarDni.UseVisualStyleBackColor = true;
            this.BtnBuscarDni.Click += new System.EventHandler(this.BtnBuscarDni_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Image")));
            this.BtnImprimir.Location = new System.Drawing.Point(687, 382);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(133, 58);
            this.BtnImprimir.TabIndex = 53;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // CmbMuestra
            // 
            this.CmbMuestra.FormattingEnabled = true;
            this.CmbMuestra.Location = new System.Drawing.Point(639, 241);
            this.CmbMuestra.Name = "CmbMuestra";
            this.CmbMuestra.Size = new System.Drawing.Size(315, 30);
            this.CmbMuestra.TabIndex = 54;
            this.CmbMuestra.Text = "Seleccione la Muestra";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.BackColor = System.Drawing.Color.White;
            this.TxtPrecio.Location = new System.Drawing.Point(342, 338);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(315, 27);
            this.TxtPrecio.TabIndex = 56;
            this.TxtPrecio.TextChanged += new System.EventHandler(this.TxtPrecio_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(255, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 21);
            this.label8.TabIndex = 55;
            this.label8.Text = "Precio:";
            // 
            // FrmMuestras
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(980, 505);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbMuestra);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.BtnBuscarDni);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.DtpFecha_reco);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtTemperatura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMuestra);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold);
            this.Name = "FrmMuestras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMuestras";
            this.Load += new System.EventHandler(this.FrmMuestras_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnAcercaDe;
        private System.Windows.Forms.Button BtnProveedores;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Button BtnVenta;
        private System.Windows.Forms.Button BtnPruebas;
        private System.Windows.Forms.Button BtnMuestras;
        private System.Windows.Forms.Button BtnPacientes;
        private System.Windows.Forms.Button BtnCitas;
        private System.Windows.Forms.Button BtnUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtMuestra;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTemperatura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DtpFecha_reco;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnBuscarDni;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.ComboBox CmbMuestra;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label8;
    }
}