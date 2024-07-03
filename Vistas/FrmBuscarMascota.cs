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
    public partial class FrmBuscarMascota : Form
    {
        Clases.DB db = new Clases.DB();
        public FrmBuscarMascota()
        {
            InitializeComponent();
        }

        private void FrmBuscarMascota_Load(object sender, EventArgs e)
        {

        }

        private void buscarMascota(string codigo)
        {
            DataTable mascotas = new DataTable();
            string campos = "CODIGO, NOMBRE, ESPECIE, EDAD";
            mascotas = db.Find("MASCOTAS", campos, $"NOMBRE LIKE '%{codigo}%'");
            DgvData.Rows.Clear();
            string _codigo, _nombre, _especie, _edad;
            foreach (DataRow infomascotas in mascotas.Rows)
            {
                _codigo = infomascotas["CODIGO"].ToString();
                _nombre = infomascotas["NOMBRE"].ToString();
                _especie = infomascotas["ESPECIE"].ToString();
                _edad = infomascotas["EDAD"].ToString();

                DgvData.Rows.Add(_codigo, _nombre, _especie, _edad);
            }
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarMascota(TxtBuscar.Text.Trim());
            }
        }

        private void DgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvData.Rows.Count > 0)
            {
                string codigo, nombre, especie;
                codigo = DgvData.CurrentRow.Cells[0].Value.ToString();
                nombre = DgvData.CurrentRow.Cells[1].Value.ToString();
                especie = DgvData.CurrentRow.Cells[2].Value.ToString();

                Vistas.FrmEmergenciasA emergencias = new Vistas.FrmEmergenciasA();
                emergencias = ((Vistas.FrmEmergenciasA)Owner);
                emergencias.RecibirDatosMascota(codigo, nombre, especie);
                this.Close();
            }
        }


    }
}
