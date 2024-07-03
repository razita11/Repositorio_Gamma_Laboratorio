using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoLaboratorio.Clases.DB;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmEmergenciasA : Form
    {
        private int idEmergencia = 1;
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        public FrmEmergenciasA()
        {
            InitializeComponent();
        }
        public void RecibirDatosMascota(string codigo, string nombre, string especie)
        {
            TxtCodigo.Text = codigo;
            TxtNombre.Text = nombre;
            TxtEspecie.Text = especie;
        }

        private void FrmEmergenciasA_Load(object sender, EventArgs e)
        {
            string lastEmergenciaId = db.GetLastEmergenciaId();

            if (!string.IsNullOrEmpty(lastEmergenciaId))
            {
                // Convertir el último ID de muestra a entero y agregar 1 para el próximo ID
                idEmergencia = int.Parse(lastEmergenciaId) + 1;
            }

            // Mostrar el próximo ID de muestra en el campo TxtMuestra
            TxtNumero.Text = idEmergencia.ToString();
            TxtNombre.Enabled = false;

        }

        private void BtnBuscarCodigo_Click(object sender, EventArgs e)
        {
            string codigo = TxtCodigo.Text.Trim();
            if (!string.IsNullOrEmpty(codigo))
            {
                Mascota mascota = db.ObtenerDatosMascota(codigo);
                if (mascota != null)
                {
                    TxtNombre.Text = mascota.Nombre;
                    TxtEspecie.Text = mascota.Especie;
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna Mascota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Codigo válido para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscador_Click(object sender, EventArgs e)
        {
            Vistas.FrmBuscarMascota frmBuscarMascota = new Vistas.FrmBuscarMascota();

            this.AddOwnedForm(frmBuscarMascota);
            frmBuscarMascota.Show();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos del formulario
            string Codigo = TxtCodigo.Text;
            string motivo = TxtMotivo.Text;
            string detalle = TxtDetalle.Text;
            string diagnostico = TxtDiagnostico.Text;
            string receta = TxtReceta.Text;
            string fechaRecoleccion = DtpFecha.Value.ToString("yyyy-MM-dd");

            // Guardar los valores en la base de datos
            string columnas = "FECHA, MASCOTA_CODIGO, MOTIVO, DETALLE, DIAGNOSTICO,RECETA";
            string valores = $"'{fechaRecoleccion}', '{Codigo}', '{motivo}', '{detalle}','{diagnostico}','{receta}'";
            if (db.Save("EMERGENCIAS", columnas, valores))
            {
                MessageBox.Show("La muestra se registró correctamente.");
                idEmergencia++; // Incrementar el ID de la muestra para la próxima muestra
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la Emeregencia");
            }
        }
        private void ClearForm()
        {
            TxtCodigo.Clear();
            TxtReceta.Clear();
            TxtNumero.Clear();
            TxtNombre.Clear();
            TxtDetalle.Clear();
            TxtEspecie.Clear();
            TxtDiagnostico.Clear();
            TxtMotivo.Clear();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.Mascotas.FrmReproteEmergencias frm = new Reportes.Mascotas.FrmReproteEmergencias();
            frm.Show();
        }
    }
}
