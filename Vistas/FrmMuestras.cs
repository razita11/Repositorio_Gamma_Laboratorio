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
    public partial class FrmMuestras : Form
    {
        private int idMuestra = 1; // Variable para almacenar el ID de la muestra
        Clases.DB db = new Clases.DB();// Instancia de la clase de conexión a la base de datos
        Clases.Auth auth = new Clases.Auth();   
        Clases.Helpers h = new Clases.Helpers();
        public FrmMuestras()
        {
            InitializeComponent();
            CmbMuestra.Items.Add("Seleccione una muestra");
            CmbMuestra.SelectedIndex = 0; // Establecer este elemento como seleccionado por defecto
            //CmbMuestra.SelectedIndexChanged += CmbMuestra_SelectedIndexChanged;
            ClearForm();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTemperatura_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmMuestras_Load(object sender, EventArgs e)
        {
            // Obtener el último ID de muestra registrado
            string lastMuestraId = db.GetLastMuestraId();

            if (!string.IsNullOrEmpty(lastMuestraId))
            {
                // Convertir el último ID de muestra a entero y agregar 1 para el próximo ID
                idMuestra = int.Parse(lastMuestraId) + 1;
            }

            // Mostrar el próximo ID de muestra en el campo TxtMuestra
            TxtMuestra.Text = idMuestra.ToString();
            TxtMuestra.Enabled = false;
            TxtNombre.Enabled= false;
            TxtPrecio.Enabled = false;
            TxtCodigo.Enabled = false;
            DtpFecha_reco.Enabled = false;

            // Obtener las muestras
            DataTable muestras = db.Find("REGISTRO_MUESTRA", "ID_MUESTRA, NOMBRE, PRECIO");

            // Limpiar ComboBox antes de agregar las nuevas muestras
            CmbMuestra.Items.Clear();
            // Recorrer el DataTable para agregar las muestras al ComboBox
            foreach (DataRow row in muestras.Rows)
            {
                string nombre = row["NOMBRE"].ToString();
                CmbMuestra.Items.Add(nombre);
            }

            // Seleccionar la primera muestra por defecto

           //if (CmbMuestra.Items.Count > 0)
            //{
              //  CmbMuestra.SelectedIndex = 0;
            //}
            CmbMuestra.SelectedIndexChanged += CmbMuestra_SelectedIndexChanged;

        }

        private void CmbMuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable muestras = db.Find("REGISTRO_MUESTRA", "ID_MUESTRA, NOMBRE, PRECIO");

            // Obtener el índice seleccionado en el ComboBox
            int selectedIndex = CmbMuestra.SelectedIndex;

            // Asegurarse de que se haya seleccionado algo
            if (selectedIndex >= 0 && selectedIndex < muestras.Rows.Count)
            {
                // Obtener el ID correspondiente del DataTable original usando el índice seleccionado
                string muestraId = muestras.Rows[selectedIndex]["ID_MUESTRA"].ToString();
                string precioMuestra = muestras.Rows[selectedIndex]["PRECIO"].ToString();

                // Mostrar el ID en el campo TxtCodigo
                TxtCodigo.Text = muestraId;
                TxtPrecio.Text = precioMuestra;
            }
        }


        private void TxtMuestra_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string usuarioRegistro = auth.ObtenerUsuarioSesion();

            // Verificar que se haya obtenido el nombre de usuario
            if (string.IsNullOrEmpty(usuarioRegistro))
            {
                h.advertencia("No se pudo obtener el nombre de usuario de la sesión.");
                return;
            }

            // Obtener los valores de los campos del formulario
            //string tipoMuestra = TxtTipoMuestra.Text;
            string tipoMuestra = CmbMuestra.Text;
            string codigo = TxtCodigo.Text;
            string fechaRecoleccion = DtpFecha_reco.Value.ToString("yyyy-MM-dd");
            string temperatura = TxtTemperatura.Text;
            string dni_paciente = TxtDni.Text;
            string precio = TxtPrecio.Text;

            // Guardar los valores en la base de datos
            string columnas = "TIPO_MUESTRA, CODIGO, FECHA_RECO, TEMPERATURA, DNI_PACIENTE, PRECIO,USUARIO";
            string valores = $"'{tipoMuestra}', '{codigo}', '{fechaRecoleccion}', '{temperatura}','{dni_paciente}','{precio}','{usuarioRegistro}'";
            if (db.Save("MUESTRAS", columnas, valores))
            {
                MessageBox.Show("La muestra se registró correctamente.");
                TxtMuestra.Text = idMuestra.ToString(); // Mostrar el ID de la muestra en el campo TxtMuestra
                idMuestra++; // Incrementar el ID de la muestra para la próxima muestra
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la muestra.");
            }
        }
        private void ClearForm()
        {
            TxtCodigo.Clear();
            TxtTemperatura.Clear();
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtDni.Clear();
            TxtPrecio.Clear();
        }

        private void BtnBuscarDni_Click(object sender, EventArgs e)
        {
            string dni = TxtDni.Text.Trim();
            if (!string.IsNullOrEmpty(dni))
            {
                string nombre = db.ObtenerNombrePaciente(dni);
                if (!string.IsNullOrEmpty(nombre))
                {
                    TxtNombre.Text = nombre;
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Vistas.Buscar.FrmBuscarMuestra frmBuscarMuestra = new Vistas.Buscar.FrmBuscarMuestra();
            frmBuscarMuestra.Show();
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Vistas.FrmPacientes frmPacientes = new Vistas.FrmPacientes();
            frmPacientes.Show();
        }

        private void BtnPruebas_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas frmPruebas = new Vistas.FrmPruebas();
            frmPruebas.Show();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.Muestras.FrmRptGralMuestra frm = new Reportes.Muestras.FrmRptGralMuestra();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.FrmRegistrarMuestra registerm = new Vistas.FrmRegistrarMuestra();
            registerm.Show();
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Vistas.FrmUsuarios usuarios = new Vistas.FrmUsuarios();
            usuarios.Show();
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            Vistas.FrmCitas citas = new Vistas.FrmCitas();
            citas.Show();
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
