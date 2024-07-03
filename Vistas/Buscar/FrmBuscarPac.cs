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

namespace ProyectoLaboratorio.Vistas.Buscar
{
    public partial class FrmBuscarPac : Form
    {
        string dni, nombres, apellidos, correo, sexo, fechanac, telefono, direccion;
        DateTime fechanaci;

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string msg = "¿Desea Actualizar los Cambios del paciente?";

            if (h.Question(msg) == true)
            {
                Setvalues();
                DateTime fechaNacimiento;
                if (DateTime.TryParseExact(DtpFecha_nac.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
                {
                    string actualizar = $"NOMBRE='{nombres}',APELLIDOS='{apellidos}',DIRECCION='{direccion}',TELEFONO='{telefono}',SEXO='{sexo}',FECHANAC='{fechanac}'";
                    string condicion = $"DNI='{dni}'";
                    if (db.update("PACIENTES", actualizar, condicion) > 0)
                    {
                        h.Success("Los Datos se actualizaron con Éxito");
                        ClearForm();
                        Boot();
                        ListarPacientes();
                    }
                }
                else
                {
                    h.advertencia("Formato de fecha incorrecto. Utiliza el formato d/m/a (día/mes/año).");
                }
            }
        }

        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarPacientes(TxtBuscar.Text.Trim());
        }
        private bool CancelarAdvertencia = false;
        public FrmBuscarPac()
        {
            InitializeComponent();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string msg = "¿Desea Eliminar El Paciente de la base datos?";

            if (h.Question(msg) == true)
            {
                if (db.Destroy("PACIENTES", $"DNI='{TxtDni.Text.Trim()}'") > 0)
                {
                    h.Success("El Paciente se eliminó con Éxito");
                    ClearForm();
                    ListarPacientes();
                    Boot();
                }
            }
        }

        private void DgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvData.Rows.Count > 0)
            {
                string _dni = DgvData.CurrentRow.Cells[0].Value.ToString();
                getInfoPacientes(_dni);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Setvalues()
        {
            dni = TxtDni.Text;
            nombres = TxtNombre.Text;
            apellidos = TxtApellidos.Text;
            correo = TxtCorreo.Text;
            sexo = TxtSexo.Text;
            fechanac = DtpFecha_nac.Text;
            telefono = TxtTelefono.Text;
            direccion = TxtDireccion.Text;
        }

        private void FrmBuscarPac_Load(object sender, EventArgs e)
        {
            ListarPacientes();
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

            DgvData.Rows.Clear();

            //DgvDatap.Rows.Clear();

            string _dni, _nombres, _apellidos, _fechanac;
            foreach (DataRow Paciente in pacientes.Rows)
            {
                _dni = Paciente["DNI"].ToString();
                _nombres = Paciente["NOMBRE"].ToString();
                _apellidos = Paciente["APELLIDOS"].ToString();
                _fechanac = Paciente["FECHANAC"].ToString();
                DgvData.Rows.Add(_dni, _nombres, _apellidos, _fechanac);

                //DgvDatap.Rows.Add(_dni, _nombres, _apellidos, _fechanac);

            }

            pacientes.Dispose();
        }

        private void getInfoPacientes(string no_dni)
        {
            CancelarAdvertencia = true;

            DataTable Paciente = db.Find("PACIENTES", "*", $"DNI='{no_dni}'");
            if (Paciente.Rows.Count > 0)
            {
                DataRow info = Paciente.Rows[0];
                TxtDni.Text = info["DNI"].ToString();
                TxtDni.Enabled = false;
                TxtNombre.Text = info["NOMBRE"].ToString();
                TxtApellidos.Text = info["APELLIDOS"].ToString();
                TxtDireccion.Text = info["DIRECCION"].ToString();
                TxtTelefono.Text = info["TELEFONO"].ToString();
                TxtCorreo.Text = info["CORREO"].ToString();
                DtpFecha_nac.Text = info["FECHANAC"].ToString();
                TxtSexo.Text = info["SEXO"].ToString();
                BtnEliminar.Enabled = true;
                BtnActualizar.Enabled = true;
            }
            CancelarAdvertencia = false;
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

        private void Boot()
        {
            BtnEliminar.Enabled = false;
        }


    }
}
