using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas.Buscar
{
    public partial class FrmBuscarCitas : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        public FrmBuscarCitas()
        {
            InitializeComponent();
        }

        private void FrmBuscarCitas_Load(object sender, EventArgs e)
        {
            TxtNombre.Enabled = false;
            ListarCitas();
        }

        private void GetInfoCitas(string id)
        {
            //CancelarAdvertencia = true;

            DataTable Muestra = db.Find("CITAS", "*", $"CITA_ID='{id}'");
            if (Muestra.Rows.Count > 0)
            {
                DataRow info = Muestra.Rows[0];
                TxtDni.Text = info["DNI_PACIENTE"].ToString();
                CmbEstado.Text = info["ESTADO_CITA"].ToString();
                CmbTipoCita.Text = info["TIPO_CITA"].ToString();
                DtpFecha_Cita.Text = info["FECHA_CITA"].ToString();
                Dtp_Hora.Text = info["HORA_CITA"].ToString();
                TxtObservaciones.Text = info["OBSERVACIONES_CITA"].ToString();

                DateTime fechaCita;
                if (DateTime.TryParse(info["FECHA_CITA"].ToString(), out fechaCita))
                {
                    DtpFecha_Cita.Value = fechaCita;
                }
                else
                {
                    // Manejar el caso en que la conversión de fecha falle
                    h.advertencia("Error al convertir la fecha.");
                }

                // Asignar el valor de fecha al campo fecharec
                fechaCita = DtpFecha_Cita.Value;

                TxtDni.Enabled = false;
                TxtNombre.Enabled = false;
                BtnEliminar.Enabled = true;
                BtnActualizar.Enabled = true;

                DataTable paciente = db.Find("PACIENTES", "NOMBRE", $"DNI='{info["DNI_PACIENTE"]}'");

                if (paciente.Rows.Count > 0)
                {
                    TxtNombre.Text = paciente.Rows[0]["NOMBRE"].ToString();
                }
                else { TxtNombre.Text = "Nombre no encontrado"; }
            }

        }
        private void ListarCitas(string id = " ")
        {
            DataTable citas;


            if (id == " ")
            {
                citas = db.Find("CITAS", "CITA_ID,DNI_PACIENTE, ESTADO_CITA, TIPO_CITA, FECHA_CITA,HORA_CITA,OBSERVACIONES_CITA");

            }
            else
            {
                string _condicion = $"CITA_ID LIKE'%{id}%'";
                citas = db.Find("CITAS", "CITA_ID,DNI_PACIENTE, ESTADO_CITA, TIPO_CITA, FECHA_CITA,HORA_CITA,OBSERVACIONES_CITA", _condicion);
            }

            DgvData.Rows.Clear();


            string _dnipaciente, _estado, _tipo, _fecha, _hora, _observaciones, cita_id;
            foreach (DataRow Cita in citas.Rows)
            {
                string dniPaciente = Cita["DNI_PACIENTE"].ToString();
                DataTable paciente = db.Find("PACIENTES", "NOMBRE", $"DNI='{dniPaciente}'");
                string nombrePaciente = (paciente.Rows.Count > 0) ? paciente.Rows[0]["NOMBRE"].ToString() : "Nombre no encontrado";
                _dnipaciente = Cita["DNI_PACIENTE"].ToString();
                _estado = Cita["ESTADO_CITA"].ToString();
                _tipo = Cita["ESTADO_CITA"].ToString();
                _fecha = Cita["FECHA_CITA"].ToString();
                _hora = Cita["HORA_CITA"].ToString();
                cita_id = Cita["CITA_ID"].ToString();

                DgvData.Rows.Add(cita_id, nombrePaciente, _tipo, _fecha, _hora);

                //DgvDatap.Rows.Add(_dni, _nombres, _apellidos, _fechanac);

            }

            citas.Dispose();
        }

        private void DgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvData.Rows.Count > 0)
            {
                string id = DgvData.CurrentRow.Cells[0].Value.ToString();
                GetInfoCitas(id);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarCitas(TxtBuscar.Text.Trim());
        }

        private void BtnMuestras_Click(object sender, EventArgs e)
        {
            Vistas.FrmMuestras muuestras = new Vistas.FrmMuestras();
            muuestras.Show();
        }

        private void BtnPruebas_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas pruebas = new Vistas.FrmPruebas();
            pruebas.Show();
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Vistas.FrmPacientes pacientes = new Vistas.FrmPacientes();
            pacientes.Show();
        }
    }
}
