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
    public partial class FrmPruebas : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        Clases.Auth auth = new Clases.Auth();
        private int idMuestra = 1; // Variable para almacenar el ID de la muestra
        public FrmPruebas()
        {
            InitializeComponent();
            CmbPrueba.Items.Add("Seleccione una muestra");
            CmbPrueba.SelectedIndex = 0; // Establecer este elemento como seleccionado por defecto
        }

        private void FrmPruebas_Load(object sender, EventArgs e)
        {
            // Obtener el último ID de muestra registrado
            string lastPruebaId = db.GetLastPruebaId();

            if (!string.IsNullOrEmpty(lastPruebaId))
            {
                // Convertir el último ID de muestra a entero y agregar 1 para el próximo ID
                idMuestra = int.Parse(lastPruebaId) + 1;
            }

            // Mostrar el próximo ID de muestra en el campo TxtMuestra
            TxtContPrueba.Text = idMuestra.ToString();

            DataTable muestras = db.Find("REGISTRO_PRUEBA", "ID_PRUEBA, NOMBRE, PRECIO");

            // Limpiar ComboBox antes de agregar las nuevas muestras
            CmbPrueba.Items.Clear();
            // Recorrer el DataTable para agregar las muestras al ComboBox
            foreach (DataRow row in muestras.Rows)
            {
                string nombre = row["NOMBRE"].ToString();
                CmbPrueba.Items.Add(nombre);
            }

            // Seleccionar la primera muestra por defecto

            //if (CmbPrueba.Items.Count > 0)
            //{
              //  CmbPrueba.SelectedIndex = 0;
            //}
            CmbPrueba.SelectedIndexChanged += CmbPrueba_SelectedIndexChanged;
        }

        private void CmbPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable muestras = db.Find("REGISTRO_PRUEBA", "ID_PRUEBA, NOMBRE, PRECIO");

            // Obtener el índice seleccionado en el ComboBox
            int selectedIndex = CmbPrueba.SelectedIndex;

            // Asegurarse de que se haya seleccionado algo
            if (selectedIndex >= 0 && selectedIndex < muestras.Rows.Count)
            {
                // Obtener el ID correspondiente del DataTable original usando el índice seleccionado
                string pruebaId = muestras.Rows[selectedIndex]["ID_PRUEBA"].ToString();
                string precioMuestra = muestras.Rows[selectedIndex]["PRECIO"].ToString();

                // Mostrar el ID en el campo TxtCodigo
                TxtCodigo.Text = pruebaId;
                TxtPrecio.Text = precioMuestra;
            }
        }

        private void BtnBuscarMuestra_Click(object sender, EventArgs e)
        {
            string muestraId = TxtMuestraId.Text.Trim();
            if (!string.IsNullOrEmpty(muestraId))
            {
                // Obtener el tipo de muestra
                string tipoMuestra = db.ObtenerNombreMuestra(muestraId);
                TxtTipoMuestra.Text = tipoMuestra;

                // Obtener el nombre del paciente
                string nombrePaciente = db.ObtenerNombrePacienteEnPrueba(muestraId);
                if (!string.IsNullOrEmpty(nombrePaciente))
                {
                    TxtPaciente.Text = nombrePaciente;
                }
                else
                {
                    TxtPaciente.Text = "No encontrado";
                }
            }
            else
            {
                // Limpiar los campos si el MUESTRA_ID está vacío
                TxtTipoMuestra.Clear();
                TxtPaciente.Clear();
            }

        }

        private void TxtMuestraId_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTipoMuestra_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPaciente_TextChanged(object sender, EventArgs e)
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

            string tipoPrueba = CmbPrueba.Text;
            string resultado = TxtResultado.Text;
            string rango = TxtRango.Text;
            string unidad= TxtUnidad.Text;
            string fecha = DtpFecha_Prueba.Value.ToString ("yyyy-MM-dd");
            string idmuestra = TxtMuestraId.Text;
            string precio = TxtPrecio.Text;
            string codigo = TxtCodigo.Text;

            string columnas = "MUESTRA_ID,TIPO_PRUEBA,RESULTADO,FECHA_RESULTADO,UNIDAD_MEDIDA,RANGO_NORMAL,PRECIO,CODIGO,USUARIO";
            string valores = $"'{idmuestra}','{tipoPrueba}','{resultado}','{fecha}','{unidad}','{rango}','{precio}','{codigo}','{usuarioRegistro}'";

            if (db.Save("PRUEBAS",columnas, valores))
            {

                h.Success("La Prueba se registró correctamente.");
                ClearForm();
                TxtMuestraId.Focus();
            }
            else
            {
                h.advertencia("Error al registrar la Prueba.");
            }
        }

        private void ClearForm()
        {
            TxtMuestraId.Clear();
            TxtPaciente.Clear();
            TxtRango.Clear();
            TxtResultado.Clear();
            TxtTipoMuestra.Clear();
            TxtUnidad.Clear();
            TxtPrecio.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Vistas.Buscar.FrmBuscarPrueba frmBuscarPrueba = new Vistas.Buscar.FrmBuscarPrueba();
            frmBuscarPrueba.Show();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.Muestras.FrmRptGralMuestra frm = new Reportes.Muestras.FrmRptGralMuestra();
            frm.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vistas.FrmRegistrarPrueba registerP = new Vistas.FrmRegistrarPrueba();
            registerP.Show();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Vistas.FrmUsuarios usuarios = new Vistas.FrmUsuarios();
            usuarios.Show();
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

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            Vistas.FrmInventario inventarip = new Vistas.FrmInventario();
            inventarip.Show();
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
