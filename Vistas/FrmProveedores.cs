using ProyectoLaboratorio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmProveedores : Form
    {
        Clases. DB db = new DB();
        Clases.Helpers h = new Helpers();
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string rtn = TxtRtn.Text;
            string nombre = TxtNombre.Text;
            string correo = TxtCorreo.Text;
            string direccion = TxtDireccion.Text;
            string telefono = TxtTelefono.Text;
            string fecha = DtpFecha.Text;


            string columnas = "RTN,NOMBRE_OR_RAZON,CORREO,FECHA_INGRESO,TELEFONO,DIRECCION";
            string valores = $"'{rtn}','{nombre}','{correo}','{fecha}','{telefono}','{direccion}'";

            if (db.Save("PROVEEDORES", columnas, valores))
            {
                h.Success("El Paciente se Registró con Éxito");
                ClearForm();
                TxtRtn.Focus();
            }

        }

        private void ClearForm()
        {
            TxtRtn.Clear();
            TxtNombre.Clear();
            TxtDireccion.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
        }

    }
}
