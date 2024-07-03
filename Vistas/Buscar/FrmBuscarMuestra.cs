using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Vistas.Buscar
{
    public partial class FrmBuscarMuestra : Form
    {
        Clases.DB db = new Clases.DB ();
        Clases.Helpers h= new Clases.Helpers ();
        string dni, fecha_recibo, muestra, temperatura, codigo, nombre, muestra_id;
        DateTime fecharec;

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarMuestras(TxtBuscar.Text.Trim());
        }

        private void DgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvData.Rows.Count > 0)
            {
                string no_dni = DgvData.CurrentRow.Cells[0].Value.ToString();
                getInfoMuestras(no_dni);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string msg = "¿Desea Actualizar los Cambios de la Muestra?";

            if (h.Question(msg) == true)
            {
                SetValues();
                              
                   string actualizar = $"CODIGO='{codigo}',TIPO_MUESTRA='{muestra}',FECHA_RECO='{fecharec}',TEMPERATURA='{temperatura}'";
                    string condicion = $"MUESTRA_ID='{muestra_id}'";
                    if (db.update("MUESTRAS", actualizar, condicion) > 0)
                    {
                        h.Success("Los Datos se actualizaron con Éxito");
                        ClearForm();
                        Boot();
                        ListarMuestras();
                    }
            }
        }

        private void ClearForm()
        {
            TxtDni.Clear();
            TxtNombre.Clear();
            TxtCodigo.Clear();
            TxtMuestra.Clear();
            TxtTemperatura.Clear();
            TxtMuestra_id.Clear();
        }
        private void Boot()
        {
            BtnEliminar.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string msg = "¿Desea Eliminar La muestra de la base datos?";

            if (h.Question(msg) == true)
            {
                int muestraId;
                if (int.TryParse(TxtMuestra_id.Text.Trim(), out muestraId))
                {
                    if (db.Destroy("MUESTRAS", $"MUESTRA_ID={muestraId}") > 0)
                    {
                        h.Success("La Muestra se eliminó con Éxito");
                        ClearForm();
                        ListarMuestras();
                        Boot();
                    }
                }
                else
                {
                    h.advertencia("El valor de MUESTRA_ID no es válido.");
                }
            }
        }

        private void DtpFecha_recibo_ValueChanged(object sender, EventArgs e)
        {
            fecharec = DtpFecha_recibo.Value;
        }

        private void BtnPruebas_Click(object sender, EventArgs e)
        {
            Vistas.FrmPruebas frmPruebas = new Vistas.FrmPruebas();
            frmPruebas.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public FrmBuscarMuestra()
        {
            InitializeComponent();
        }

        private void FrmBuscarMuestra_Load(object sender, EventArgs e)
        {
            ListarMuestras();

        }

        private void SetValues()
        {
            dni = TxtDni.Text;
            nombre = TxtNombre.Text;
            muestra = TxtMuestra.Text;
            fecha_recibo= DtpFecha_recibo.Text;
            muestra_id = TxtMuestra_id.Text;
            codigo = TxtCodigo.Text;
            temperatura = TxtTemperatura.Text;
        }

        private void ListarMuestras(string id = " ")
        {
            DataTable muestras;
          

            if (id == " ")
            {
                muestras = db.Find("MUESTRAS", "MUESTRA_ID, DNI_PACIENTE, CODIGO, TIPO_MUESTRA, FECHA_RECO,TEMPERATURA");

            }
            else
            {
                string _condicion = $"MUESTRA_ID LIKE'%{id}%'";
                muestras = db.Find("MUESTRAS", "MUESTRA_ID, DNI_PACIENTE, CODIGO, TIPO_MUESTRA, FECHA_RECO,TEMPERATURA",_condicion);
            }

            DgvData.Rows.Clear();

            //DgvDatap.Rows.Clear();


            string _muestraid,_dnipaciente, _codigo, _tipomuestra, _fecha_reco,_nombre;
            foreach (DataRow Muestra in muestras.Rows)
            {
                string dniPaciente = Muestra["DNI_PACIENTE"].ToString();
                DataTable paciente = db.Find("PACIENTES", "NOMBRE", $"DNI='{dniPaciente}'");
                string nombrePaciente = (paciente.Rows.Count > 0) ? paciente.Rows[0]["NOMBRE"].ToString() : "Nombre no encontrado";
                _dnipaciente = Muestra["DNI_PACIENTE"].ToString();
                _muestraid = Muestra["MUESTRA_ID"].ToString();
                _codigo = Muestra["CODIGO"].ToString();
                _tipomuestra= Muestra["TIPO_MUESTRA"].ToString();
                _fecha_reco = Muestra["FECHA_RECO"].ToString();
                DgvData.Rows.Add(_muestraid, nombrePaciente, _tipomuestra, _codigo, _fecha_reco);

                //DgvDatap.Rows.Add(_dni, _nombres, _apellidos, _fechanac);

            }

            muestras.Dispose();
        }

        private void getInfoMuestras(string no_dni)
        {
            //CancelarAdvertencia = true;

            DataTable Muestra= db.Find("MUESTRAS", "*", $"MUESTRA_ID='{no_dni}'");
            if (Muestra.Rows.Count > 0)
            {
                DataRow info = Muestra.Rows[0];
                TxtDni.Text = info["DNI_PACIENTE"].ToString();
                TxtCodigo.Text = info["CODIGO"].ToString();
                TxtMuestra.Text = info["TIPO_MUESTRA"].ToString();
                TxtTemperatura.Text = info["TEMPERATURA"].ToString();
                DtpFecha_recibo.Text = info["FECHA_RECO"].ToString();
                TxtMuestra_id.Text = info["MUESTRA_ID"].ToString();

                // Convertir la fecha a un formato adecuado
                DateTime fechaRecibo;
                if (DateTime.TryParse(info["FECHA_RECO"].ToString(), out fechaRecibo))
                {
                    DtpFecha_recibo.Value = fechaRecibo;
                }
                else
                {
                    // Manejar el caso en que la conversión de fecha falle
                    h.advertencia("Error al convertir la fecha.");
                }

                // Asignar el valor de fecha al campo fecharec
                fecharec = DtpFecha_recibo.Value;

                TxtDni.Enabled = false;
                TxtNombre.Enabled = false;
                TxtMuestra_id.Enabled = false;
                BtnEliminar.Enabled = true;
                BtnActualizar.Enabled = true;

                DataTable paciente = db.Find("PACIENTES", "NOMBRE", $"DNI='{info["DNI_PACIENTE"]}'"); 
                
                if (paciente.Rows.Count > 0) 
                { 
                    TxtNombre.Text = paciente.Rows[0]["NOMBRE"].ToString(); 
                }
                else { TxtNombre.Text = "Nombre no encontrado"; }

            }
            
        }
    }
    //CancelarAdvertencia = false;
}
