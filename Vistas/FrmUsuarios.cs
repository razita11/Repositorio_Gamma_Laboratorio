using ProyectoLaboratorio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmUsuarios : Form
    {
        Clases.DB db = new Clases. DB ();
        Clases.Helpers h = new Clases.Helpers ();   
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string username, clave, nombre, genero, fechanac, correo, rol;
            username = TxtUsername.Text;
            clave = BCrypt.Net.BCrypt.HashPassword(TxtContraseña.Text);
            nombre = TxtNombre.Text;
            genero = CmbSexo.Text;
            fechanac = DtpFecha_nac.Value.ToString("yyyy-MM-dd");
            correo = TxtCorreo.Text;
            rol = CmbRol.Text;

            string columnas = "USERNAME,CLAVE,NOMBRE,GENERO,FECHA_NAC,CORREO,ROL";
            string valores = $"'{username}','{clave}','{nombre}','{genero}','{fechanac}','{correo}','{rol}'"; 


            if (db.Save("USUARIOS", columnas, valores))
            {
                MessageBox.Show("El Usuario Se Registró Con Exito.");
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la muestra.");
            }
        }

        private void ClearForm()
        {
            TxtUsername.Clear();
            TxtNombre.Clear();
            TxtCorreo.Clear();
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Vistas.FrmPacientes frmPacientes = new Vistas.FrmPacientes();
            frmPacientes.Show();
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            Vistas.FrmCitas citas = new Vistas.FrmCitas();
            citas.Show();
        }

        private void BtnMuestras_Click(object sender, EventArgs e)
        {
            Vistas.FrmMuestras muestras = new Vistas.FrmMuestras();
            muestras.Show();
        }

        private void BtnPruebas_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas frmPruebas = new Vistas.FrmPruebas();
            frmPruebas.Show();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            Vistas.FrmInventario inventario = new Vistas.FrmInventario();
            inventario.Show();
        }

        private void BtnVenta_Click(object sender, EventArgs e)
        {
            Vistas.FrmFacturas facturas = new Vistas.FrmFacturas();
            facturas.Show();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Vistas.FrmProveedores proveedores = new Vistas.FrmProveedores();
            proveedores.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
