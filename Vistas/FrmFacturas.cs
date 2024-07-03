using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.IO;

namespace ProyectoLaboratorio.Vistas
{
    public partial class FrmFacturas : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        Clases.Auth auth = new Clases.Auth();
        private int idMuestra = 1; // Variable para almacenar el ID de la FAct


        public FrmFacturas()
        {
            InitializeComponent();
            BloquearFact();
            // Obtener y asignar el nombre de usuario actual al TextBox TxtUsuario

        }

        private void BloquearFact()
        {
            CmbPago.SelectedIndex = 0;
            toolStripButton1.Enabled = true;
            TxtUsuario.Enabled = false;
            BtnBuscar.Enabled = false;
            TxtDni.Enabled = false;
            TxtNombre.Enabled = false;
            TxtFecha.Enabled = false;
            CmbPago.Enabled = false;
            TxtDesc.Enabled = false;
            TxtCodigo.Enabled = false;
            BtnBuscarDni.Enabled = false;
            BtnCodigo.Enabled = false;
            TxtImpExento.Enabled = false;
            TxtImpGrav15.Enabled = false;
            TxtImpSv15.Enabled = false;
            TxtTotal.Enabled = false;
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool GuardarFactura()
        {
            // Obtener los valores de los campos de la factura
            string usuarioRegistro = auth.ObtenerUsuarioSesion();
            string dni = TxtDni.Text.Trim();
            string total = TxtTotal.Text.Trim();
            string descuento = TxtDesc.Text.Trim();
            //string fechaFactura = DtpFecha.Text.Trim();
            string fechaFactura = TxtFecha.Text.Trim();
            string metodop = CmbPago.Text.Trim();
            string exento = TxtImpExento.Text.Trim();
            string grav15 = TxtImpGrav15.Text.Trim();
            string ImpSv15 = TxtImpSv15.Text.Trim();
            string totalEnLetras = ConvertirTotalALetras(Convert.ToDecimal(total)) + " " + "Lempiras";



            // Verificar que se haya obtenido el nombre de usuario
            if (string.IsNullOrEmpty(usuarioRegistro))
            {
                h.advertencia("No se pudo obtener el nombre de usuario de la sesión.");
                return false;
            }

            // Guardar la factura en la tabla FACTURAS
            string camposFactura = "FECHA_FACT, TOTAL, DESCUENTO, DNI_PACIENTE, USUARIO,METODO_P,IMPO_EXENTO,IMPO_GRAV_15,ISV_15,EN_LETRAS";
            string valoresFactura = $"'{fechaFactura}', '{total}', '{descuento}', '{dni}', '{usuarioRegistro}','{metodop}','{exento}','{grav15}','{ImpSv15}','{totalEnLetras}'";
            if (!db.Save("FACTURAS", camposFactura, valoresFactura))
            {
                h.advertencia("Error al guardar la factura.");
                return false;
            }

            // Obtener el ID de la factura recién insertada
            string facturaId = db.GetLastFacturaId();

            // Guardar el detalle de la factura en la tabla DETALLE_FACTURA
            foreach (DataGridViewRow row in DgvData.Rows)
            {
                string servicio = row.Cells["Servicios"].Value.ToString();
                decimal precioUnitario = Convert.ToDecimal(row.Cells["Precio"].Value.ToString());
                string codigo = row.Cells["Codigo"].Value.ToString();
                int idprueba = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                //decimal totalproduc = Convert.ToDecimal(row.Cells["Precio"].Value.ToString());
                int cantidad = 1; // Por ahora, asumimos que la cantidad es 1

                // Calcular el precio total del servicio
                decimal precioTotal = precioUnitario * cantidad;


                string camposDetalle = "FACTURA_ID, SERVICIO, PRECIO_U, DESCUENTO, TOTAL,CODIGO,ID_MUESTRA_P";
                string valoresDetalle = $"'{facturaId}', '{servicio}', '{precioUnitario}','{descuento}','{precioTotal}','{codigo}','{idprueba}'";

                if (!db.Save("DETALLESF", camposDetalle, valoresDetalle))
                {
                    h.advertencia("Error al guardar el detalle de la factura.");
                    // Si falla al guardar el detalle, eliminar la factura previamente registrada
                    db.Destroy("FACTURAS", $"FACTURA_ID = {facturaId}");
                    return false;
                }
            }

            // Cambiar el estado de los servicios de "Pendiente" a "Pagado"
            if (!db.ActualizarEstadoServiciosPagados(dni))
            {
                // Si falla al actualizar el estado de los servicios, mostrar advertencia
                h.advertencia("Error al actualizar el estado de los servicios.");
                return false;
            }

            // Éxito: mostrar mensaje y limpiar formulario
            h.Success("Factura registrada correctamente.");
            ImprimirFact();
            ImprimirExamenes();
            ClearForm();
            BloquearFact();

            return true;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                GuardarFactura();
                DgvData.DataSource = null;
            }
        }

        private void ImprimirFact()
        {
            Reportes.Facturacion.RptFactura rptFactura = new Reportes.Facturacion.RptFactura();
            db.print(rptFactura);
            rptFactura.SetParameterValue("@factura_id",LblFactCorre.Text.Trim());
            rptFactura.PrintToPrinter(1,false,0,0);
        }

        private void ImprimirExamenes()
        {
            Reportes.Facturacion.RptResultados rptResultados = new Reportes.Facturacion.RptResultados();
            db.print(rptResultados);
            rptResultados.SetParameterValue("@factura_id", LblFactCorre.Text.Trim());
            rptResultados.PrintToPrinter(1, false, 0, 0);
        }
        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(TxtDni.Text) ||
                string.IsNullOrWhiteSpace(TxtTotal.Text) ||
                string.IsNullOrWhiteSpace(TxtDesc.Text) ||
                string.IsNullOrWhiteSpace(TxtFecha.Text) ||
                string.IsNullOrWhiteSpace(CmbPago.Text) ||
                DgvData.Rows.Count == 0)
            {
                h.advertencia("Por favor, complete todos los campos obligatorios.");
                return false;
            }

            return true;
        }


        private void ClearForm()
        {
            TxtDni.Clear();
            TxtDesc.Clear();
            TxtDni.Clear();
            TxtImpExento.Clear();
            TxtImpGrav15.Clear();
            TxtImpSv15.Clear();
            TxtNombre.Clear();
            TxtTotal.Clear();
            DgvData.ClearSelection();
        }


        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string GenerarFact()
        {
            string nextfacutra = "";
            string lastFacturaId = db.GetLastFacturaId();

            if (!string.IsNullOrEmpty(lastFacturaId))
            {
                // Convertir el último ID de muestra a entero y agregar 1 para el próximo ID
                idMuestra = int.Parse(lastFacturaId) + 1;
                if (idMuestra >= 1 && idMuestra <= 9)
                {
                    nextfacutra = $"00000{idMuestra}";
                }
                else if (idMuestra >= 10 && idMuestra <= 99)

                {
                    nextfacutra = $"0000{idMuestra}";
                }
                else if (idMuestra >= 100 && idMuestra <= 999)

                {
                    nextfacutra = $"000{idMuestra}";
                }
                else if (idMuestra >= 1000 && idMuestra <= 9999)

                {
                    nextfacutra = $"00{idMuestra}";

                }
                else if (idMuestra >= 10000 && idMuestra <= 99999)
                {
                    nextfacutra = $"0{idMuestra}";
                }
                else
                {
                    nextfacutra = $"{idMuestra}";
                }


            }
            return nextfacutra;
            // Mostrar el próximo ID de muestra en el campo TxtMuestra
            //LblFactCorre.Text = nextfacutra.ToString();
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {

        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {

        }



        
        private void TxtImpExento_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtImpGrav15_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImpSv15_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDesc_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblFactCorre_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnBuscarDni_Click(object sender, EventArgs e)
        {
            // Obtener el DNI ingresado en el TextBox TxtDni
            string dni = TxtDni.Text;

            // Obtener el nombre completo del paciente
            string nombreCompleto = db.ObtenerNombreCompletoPaciente(dni);

            // Asignar el nombre completo del paciente al TextBox TxtNombre
            TxtNombre.Text = nombreCompleto;

            // Buscar muestras y pruebas pendientes del paciente con el DNI ingresado
            DataTable muestrasYPruebasPendientes = db.FindMuestrasYPruebasPendientes(dni);

            // Asignar el resultado al DataGridView DgvData
            DgvData.DataSource = muestrasYPruebasPendientes;

            decimal importeExento = 0;
            foreach (DataRow row in muestrasYPruebasPendientes.Rows)
            {
                importeExento += Convert.ToDecimal(row["Precio"]);
            }

            CalcularTotal();

        }

        private void CalcularTotal()
        {
            // Obtener el valor del descuento ingresado manualmente en el TextBox TxtDesc
            decimal descuento = 0;
            if (!string.IsNullOrWhiteSpace(TxtDesc.Text))
            {
                descuento = Convert.ToDecimal(TxtDesc.Text);
            }

            // Calcular el importe exento
            decimal importeExento = 0;
            foreach (DataGridViewRow row in DgvData.Rows)
            {
                importeExento += Convert.ToDecimal(row.Cells["Precio"].Value);
            }

            // Aplicar el descuento

            // Redondear el importe exento a dos decimales
            importeExento = Math.Round(importeExento, 2);

            // Calcular el importe gravado al 15%
            decimal importeGravado15 = importeExento / 1.15m;

            // Calcular el importe sujeto a retención del 15%
            decimal importeSujetoRetencion15 = importeExento - importeGravado15;

            // Redondear los importes a dos decimales
            importeGravado15 = Math.Round(importeGravado15, 2);
            importeSujetoRetencion15 = Math.Round(importeSujetoRetencion15, 2);

            // Asignar los valores calculados a los TextBox correspondientes
            TxtImpExento.Text = importeExento.ToString();
            TxtImpGrav15.Text = importeGravado15.ToString();
            TxtImpSv15.Text = importeSujetoRetencion15.ToString();

            // Calcular el total y mostrarlo
            decimal total =importeGravado15 + importeSujetoRetencion15 - descuento;
            total = Math.Round(total, 2);
            TxtTotal.Text = total.ToString();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private string ConvertirTotalALetras(decimal total)
        {
            // Lista de palabras para los números del 0 al 19
            string[] unidades = {"cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez",
                     "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"};

            // Lista de palabras para las decenas
            string[] decenas = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

            // Lista de palabras para las centenas
            string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            // Lista de palabras para los miles
            string[] miles = { "", "mil", "dos mil", "tres mil", "cuatro mil", "cinco mil", "seis mil", "siete mil", "ocho mil", "nueve mil" };

            // Valor en letras del total
            string letras = "";

            // Dividir el total en partes enteras y decimales
            int parteEntera = (int)total;
            int parteDecimal = (int)((total - parteEntera) * 100);

            // Convertir la parte entera a letras
            if (parteEntera == 0)
            {
                letras = "cero";
            }
            else if (parteEntera < 20)
            {
                letras = unidades[parteEntera];
            }
            else if (parteEntera < 100)
            {
                letras = decenas[parteEntera / 10];
                if (parteEntera % 10 != 0)
                {
                    letras += " y " + unidades[parteEntera % 10];
                }
            }
            else if (parteEntera < 1000)
            {
                letras = centenas[parteEntera / 100];
                if (parteEntera % 100 != 0)
                {
                    letras += " " + ConvertirTotalALetras(parteEntera % 100);
                }
            }
            else if (parteEntera < 10000)
            {
                letras = miles[parteEntera / 1000];
                if (parteEntera % 1000 != 0)
                {
                    letras += " " + ConvertirTotalALetras(parteEntera % 1000);
                }
            }

            // Agregar las palabras "con" y "centavos" si hay parte decimal
            if (parteDecimal > 0)
            {
                letras += " con " + parteDecimal.ToString("00") + "/100 centavos";
            }

            return letras;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TxtUsuario.Text = auth.ObtenerUsuarioSesion();
            toolStripButton1.Enabled = false; 
            LblFactCorre.Text = GenerarFact();
            BtnBuscar.Enabled =true;
            TxtDni.Enabled =true;
            TxtFecha.Text= DateTime.Today.ToShortDateString();
            CmbPago.Enabled = true;
            TxtDesc.Enabled = true;
            BtnBuscarDni.Enabled = true;
            BtnCodigo.Enabled = true;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Vistas.FrmUsuarios usuarios = new Vistas.FrmUsuarios();
            usuarios.Show();
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Vistas.FrmPacientes pacientes = new Vistas.FrmPacientes();
            pacientes.Show();
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            Vistas.FrmCitas citas = new Vistas.FrmCitas();
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

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            Vistas.FrmInventario inventario = new Vistas.FrmInventario();
            inventario.Show();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Vistas.FrmProveedores proveedores = new Vistas.FrmProveedores();
            proveedores.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
