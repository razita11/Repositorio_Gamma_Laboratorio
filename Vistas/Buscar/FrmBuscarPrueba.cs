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
    public partial class FrmBuscarPrueba : Form
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();
        string nombre, fecha_prueba, prueba, resultado, rango, medida, prueba_id;

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void DgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvData.Rows.Count > 0)
            {
                string id = DgvData.CurrentRow.Cells[0].Value.ToString();
                getInfoPruebas(id);
            }
        }

        private void BtnMuestras_Click(object sender, EventArgs e)
        {
            Vistas.FrmMuestras frmMuestras = new Vistas.FrmMuestras();
            frmMuestras.Show();
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            Vistas.FrmPacientes frmPac = new Vistas.FrmPacientes();
            frmPac.Show();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

        }

        DateTime fecharec;
        public FrmBuscarPrueba()
        {
            InitializeComponent();
        }

        private void FrmBuscarPrueba_Load(object sender, EventArgs e)
        {
            ListarPruebas();
        }

        private void ListarPruebas(string id = " ")
        {
            DataTable pruebas;

            if (id == " ")
            {
                pruebas = db.Find("PRUEBAS", "PRUEBA_ID, MUESTRA_ID, TIPO_PRUEBA,RESULTADO,FECHA_RESULTADO, UNIDAD_MEDIDA, RANGO_NORMAL");
            }
            else
            {
                string _condicion = $"PRUEBA_ID LIKE'%{id}%'";
                pruebas = db.Find("PRUEBAS", "PRUEBA_ID, MUESTRA_ID, TIPO_PRUEBA,RESULTADO,FECHA_RESULTADO, UNIDAD_MEDIDA, RANGO_NORMAL", _condicion);
            }

            DgvData.Rows.Clear();

            string _prueba_id, _muestra_id, _tipoprueba, _resultado, _fecha_resul, _unidad, _rango;
            foreach (DataRow Prueba in pruebas.Rows)
            {
                _prueba_id = Prueba["PRUEBA_ID"].ToString();
                _muestra_id = Prueba["MUESTRA_ID"].ToString();
                _tipoprueba = Prueba["TIPO_PRUEBA"].ToString();
                _resultado = Prueba["RESULTADO"].ToString();
                _fecha_resul = Prueba["FECHA_RESULTADO"].ToString();
                _unidad = Prueba["UNIDAD_MEDIDA"].ToString();
                _rango = Prueba["RANGO_NORMAL"].ToString();

                // Aqui se Obtiene el nombre del paciente asociado a la muestra
                string nombrePaciente = db.ObtenerNombrePacienteEnPrueba(_muestra_id);

                // Agregar la fila al DataGridView con el nombre del paciente y la información de la prueba
                DgvData.Rows.Add(_prueba_id, nombrePaciente, _tipoprueba, _resultado, _fecha_resul);
            }

            pruebas.Dispose();
        }

        private void getInfoPruebas(string p_id)
        {
            DataTable Prueba = db.Find("PRUEBAS", "*", $"PRUEBA_ID='{p_id}'");
            if (Prueba.Rows.Count > 0)
            {
                DataRow info = Prueba.Rows[0];
                TxtPrueba_id.Text = info["PRUEBA_ID"].ToString();
                TxtPrueba.Text = info["TIPO_PRUEBA"].ToString();
                TxtResultado.Text = info["RESULTADO"].ToString();
                TxtMedida.Text = info["UNIDAD_MEDIDA"].ToString(); 
                TxtRango.Text = info["RANGO_NORMAL"].ToString();

                // Convertir la fecha a un formato adecuado
                DateTime fechaResultado;
                if (DateTime.TryParse(info["FECHA_RESULTADO"].ToString(), out fechaResultado))
                {
                    DtpFecha.Value = fechaResultado;
                }
                else
                {
                    // Manejar el caso en que la conversión de fecha falle
                    h.advertencia("Error al convertir la fecha.");
                }

                // Obtener el nombre del paciente asociado a la prueba utilizando la relación
                string muestraId = info["MUESTRA_ID"].ToString();
                string nombrePaciente = db.ObtenerNombrePacienteEnPrueba(muestraId);

                if (!string.IsNullOrEmpty(nombrePaciente))
                {
                    TxtNombre.Text = nombrePaciente;
                }
                else
                {
                    TxtNombre.Text = "Nombre no encontrado";
                }

                TxtNombre.Enabled = false;
                TxtPrueba_id.Enabled = false;
                BtnEliminar.Enabled = true;
                BtnActualizar.Enabled = true;
            }
        }



    }
}
