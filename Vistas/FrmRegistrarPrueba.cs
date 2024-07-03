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

    public partial class FrmRegistrarPrueba : Form
    {
        Clases.DB db = new Clases.DB();
        Clases. Helpers h = new Clases.Helpers();
        public FrmRegistrarPrueba()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRegistrarPrueba_Load(object sender, EventArgs e)
        {
           
        }
        private void ClearForm()
        {
            TxtCodigo.Clear();
            TxtPrueba.Clear();
            TxtValor.Clear();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = TxtCodigo.Text;
            string prueba = TxtPrueba.Text;
            string valor = TxtValor.Text;

            string columnas = "ID_PRUEBA,NOMBRE,PRECIO";
            string valores = $"'{codigo}','{prueba}','{valor}'";
            if (db.Save("REGISTRO_PRUEBA", columnas, valores))
            {
                MessageBox.Show("La muestra se registró correctamente.");
                ClearForm(); // Limpiar el formulario después de registrar la muestra
            }
            else
            {
                h.advertencia("Error al registrar la Prueba.");
            }
        }
    }
}
