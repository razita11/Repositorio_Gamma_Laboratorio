using ProyectoLaboratorio.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmInventario : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            DataTable proveedores = db.Find("PROVEEDORES", "RTN, NOMBRE_OR_RAZON");

            // Limpiar ComboBox antes de agregar las nuevas muestras
            CmbProveedor.Items.Clear();
            // Recorrer el DataTable para agregar las muestras al ComboBox
            foreach (DataRow row in proveedores.Rows)
            {
                string nombre = row["NOMBRE_OR_RAZON"].ToString();
                CmbProveedor.Items.Add(nombre);
            }


        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
         
      

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = TxtCodigo.Text;
            string nombre = TxtNombre.Text;
            string proveedor = CmbProveedor.Text;
            string lote = CmbLote.Text;
            string ubicacion = CmbUbicacion.Text;
            string fechaCaduc = DtpFecha.Text;
            int cantidad = (int)Convert.ToInt64(TxtCantidad.Text);
            decimal precioUnitario = Convert.ToDecimal(TxtPrecio.Text);

            string columnas, valores;

            columnas = "CODIGO,NOMBRE_SUMINISTRO,CANTIDAD,FECHA_CADUCIDAD,PROVEEDOR,NUM_LOTE,UBICACION,P_UNITARIO";
            valores = $"'{codigo}','{nombre}','{cantidad}','{fechaCaduc}','{proveedor}','{lote}','{ubicacion}','{precioUnitario}'";

            if (db.Save("INVENTARIO", columnas, valores))
            {
                h.Success("El Prodducto se registró correctamente.");
                ClearForm();
                TxtCodigo.Focus();
            }
            else
            {
                h.advertencia("Error al registrar el producto");
            }
        }

        private void ClearForm()
        {
            TxtCodigo.Clear();
            TxtCantidad.Clear();
            TxtNombre.Clear();
            TxtPrecio.Clear();
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

        private void BtnPruebas_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas frmPruebas = new Vistas.FrmPruebas();
            frmPruebas.Show();
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
