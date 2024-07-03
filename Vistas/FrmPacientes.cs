using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmPacientes : Form
    {
        Clases.Helpers h = new Clases.Helpers();
        Clases.DB db = new Clases.DB();
        string dni, nombres, apellidos, correo, sexo, fechanac, telefono, direccion;

        DateTime fechanaci;


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Vistas.Buscar.FrmBuscarPac buscarPac = new Vistas.Buscar.FrmBuscarPac();
            buscarPac.Show();
        }
        private void ListarPacientes(string dni = " ")
        {
            DataTable pacientes;

            if (dni == " ")
            {
                pacientes = db.Find("PACIENTES", "DNI, NOMBRE, APELLIDOS, FECHANAC");

            }
            else
            {
                string _condicion = $"DNI LIKE'%{dni}%'";
                pacientes = db.Find("PACIENTES", "DNI, NOMBRE, APELLIDOS, FECHANAC", _condicion);
            }


            //DgvDatap.Rows.Clear();

            string _dni, _nombres, _apellidos, _fechanac;
            foreach (DataRow Paciente in pacientes.Rows)
            {
                _dni = Paciente["DNI"].ToString();
                _nombres = Paciente["NOMBRE"].ToString();
                _apellidos = Paciente["APELLIDOS"].ToString();
                _fechanac = Paciente["FECHANAC"].ToString();

                //DgvDatap.Rows.Add(_dni, _nombres, _apellidos, _fechanac);

            }

            pacientes.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            string msg = "¿Cancelar la operación en curso?";

            if (h.Question(msg) == true)
            {
                ClearForm();
                Boot();
                ListarPacientes();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vistas.FrmMuestras frmMuestras = new Vistas.FrmMuestras();
            frmMuestras.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas frmPruebas = new Vistas.FrmPruebas();
            frmPruebas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.Pacientes.FrmRptGralPacientes frmRptGralPacientes = new Reportes.Pacientes.FrmRptGralPacientes();
            frmRptGralPacientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vistas.FrmUsuarios usuarios = new Vistas.FrmUsuarios();
            usuarios.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.FrmCitas citas = new Vistas.FrmCitas();
            citas.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Vistas.FrmInventario inventario = new Vistas.FrmInventario();
            inventario.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Vistas.FrmFacturas facturas = new Vistas.FrmFacturas();
            facturas.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Vistas.FrmProveedores proveedores = new Vistas.FrmProveedores();
            proveedores.Show();
        }

        private void Boot()
        {
            button1.Enabled = true;
        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Setvalues();

            DateTime fechaNacimiento;
            if (DateTime.TryParseExact(DtpFecha_nac.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                string fechaFormatoCorrecto = fechaNacimiento.ToString("yyyy-MM-dd");
                string columnas = "DNI,NOMBRE,APELLIDOS,CORREO,FECHANAC,SEXO,TELEFONO,DIRECCION";
                string valores = $"'{dni}','{nombres}','{apellidos}','{correo}','{fechaFormatoCorrecto}','{sexo}','{telefono}','{direccion}'";

                if (db.Save("PACIENTES", columnas, valores))
                {
                    h.Success("El Paciente se Registró con Éxito");
                    ClearForm();
                    TxtDni.Focus();
                }
            }
            else
            {
                h.advertencia("Formato de fecha incorrecto. Utiliza el formato d/m/a (día/mes/año).");
            }
        }
        public FrmPacientes()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            TxtDni.Clear();
            TxtNombre.Clear();
            TxtApellidos.Clear();
            TxtSexo.Clear();
            TxtDireccion.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
       
        }

        private void Setvalues()
        {
            dni = TxtDni .Text;
            nombres = TxtNombre.Text;
            apellidos=TxtApellidos.Text;
            correo = TxtCorreo.Text;
            sexo = TxtSexo.Text;
            direccion = TxtDireccion.Text;
            telefono = TxtTelefono.Text; 
        }

    }
}
