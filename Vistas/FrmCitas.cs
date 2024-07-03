using ProyectoLaboratorio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmCitas : Form
    {
        Clases.DB db = new Clases.DB ();
        Clases.Helpers h = new Clases.Helpers();
        private int idMuestra = 1; // Variable para almacenar el ID de la muestra
        public FrmCitas()
        {
            InitializeComponent();
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {
            TxtApellidos.Enabled = false;
            TxtNombre.Enabled = false;
            string lastMuestraId = db.GetLastCitaId();

            if (!string.IsNullOrEmpty(lastMuestraId))
            {
                // Convertir el último ID de muestra a entero y agregar 1 para el próximo ID
                idMuestra = int.Parse(lastMuestraId) + 1;
            }

            // Mostrar el próximo ID de muestra en el campo TxtMuestra
            TxtMuestra.Text = idMuestra.ToString();
        }



        private void BtnBuscarDni_Click(object sender, EventArgs e)
        {
            string dni = TxtDni.Text.Trim();
            if (!string.IsNullOrEmpty(dni))
            {
                string nombre = db.ObtenerNombrePaciente(dni);
                string apellido = db.ObtenerApellidoPaciente(dni);
                if (!string.IsNullOrEmpty(nombre))
                {
                    TxtNombre.Text = nombre;
                    TxtApellidos.Text = apellido;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún paciente con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un DNI válido para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos del formulario

            string fecha_cita = DtpFecha_Cita.Value.ToString("yyyy-MM-dd");
            string hora_cita = Dtp_Hora.Text;
            string tipo_cita = CmbTipoCita.Text;
            string estado = CmbEstado.Text;
            string observaciones = TxtObservaciones.Text;
            string dni_paciente = TxtDni.Text;

            // Guardar los valores en la base de datos
            string columnas = "DNI_PACIENTE,FECHA_CITA,HORA_CITA,TIPO_CITA,ESTADO_CITA,OBSERVACIONES_CITA";
            string valores = $"'{dni_paciente}','{fecha_cita}','{hora_cita}', '{tipo_cita}', '{estado}','{observaciones}'";
            if (db.Save("CITAS", columnas, valores))
            {
                MessageBox.Show("La muestra se registró correctamente.");
                TxtMuestra.Text = idMuestra.ToString(); // Mostrar el ID de la muestra en el campo TxtMuestra
                idMuestra++; // Incrementar el ID de la muestra para la próxima muestra
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la Cita.");
            }
        }

        private void TxtMuestra_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            TxtApellidos.Clear();
            TxtNombre.Clear();
            TxtObservaciones.Clear();
            TxtDni.Clear();
        }

        private bool notificacionMostrada = false;


        private void ObtenerCitas()
        {
            // Obtener la fecha actual en el formato correcto
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");

            // Buscar citas programadas para hoy en la base de datos
            DataTable citasHoy = db.Find("CITAS", "*", $"FECHA_CITA = '{fechaActual}'");
            if (citasHoy.Rows.Count > 0)
            {
                // Mostrar un mensaje con las citas programadas
                StringBuilder mensaje = new StringBuilder();
                mensaje.AppendLine("Hoy tiene las siguientes citas:");
                foreach (DataRow cita in citasHoy.Rows)
                {
                    string hora = cita["HORA_CITA"].ToString();
                    string tipoCita = cita["TIPO_CITA"].ToString();
                    string estado = cita["ESTADO_CITA"].ToString();
                    string observaciones = cita["OBSERVACIONES_CITA"].ToString();

                    // Obtener el DNI del paciente asociado a la cita
                    string dniPaciente = cita["DNI_PACIENTE"].ToString();

                    // Obtener el nombre y apellido del paciente usando el DNI
                    string nombreApellido = db.ObtenerNombreApellidoPaciente(dniPaciente);
                    if (estado == "Pendiente")
                    {
                        MessageBox.Show(mensaje.ToString(), "Citas Programadas para Hoy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        h.Success($"- A las {hora} con el paciente {nombreApellido}. Tipo de cita: {tipoCita}, Estado: {estado}, Observaciones: {observaciones}");
                    }
                    if (DateTime.Parse(cita["FECHA_CITA"].ToString()) < DateTime.Today)
                    {
                        // Si la fecha de la cita ha pasado, cambiar el estado a "Perdida"
                        db.update("CITAS", "ESTADO_CITA = 'Perdida (o No Asistida)'", $"CITA_ID = {cita["CITA_ID"]}");
                    }

                }
     

                // Desactivar el temporizador después de mostrar la notificación
            }
            else
            {
                Console.WriteLine("No hay citas programadas para hoy.");
            }


        }

        private void BtnCitaHoy_Click(object sender, EventArgs e)
        {
            ObtenerCitas();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Vistas.Buscar.FrmBuscarCitas citas = new Vistas.Buscar.FrmBuscarCitas();
            citas.Show();
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Vistas.FrmUsuarios usuarios = new Vistas.FrmUsuarios();
            usuarios.Show();
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
    }
}
