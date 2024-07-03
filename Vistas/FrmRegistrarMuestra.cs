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
    public partial class FrmRegistrarMuestra : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        public FrmRegistrarMuestra()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRegistrarMuestra_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = TxtCodigo.Text;
            string muestra = TxtMuestra.Text;
            string precio = TxtValor.Text;

            string columnas = "ID_MUESTRA,NOMBRE,PRECIO";
            string valores = $"'{codigo}','{muestra}','{precio}'";
            if (db.Save("REGISTRO_MUESTRA", columnas, valores))
            {
                MessageBox.Show("La muestra se registró correctamente.");
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la Muestra.");
            }
        }

        private void ClearForm()
        {
            TxtCodigo.Clear();
            TxtMuestra.Clear();
            TxtValor.Clear();
        }
    }
}
