using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Reportes.Pacientes
{
    public partial class FrmRptGralPacientes : Form
    {
        public FrmRptGralPacientes()
        {
            InitializeComponent();
        }

        private void FrmRptGralPacientes_Load(object sender, EventArgs e)
        {
            Reportes.Pacientes.CRReporteGralPacientes pacientes = new Reportes.Pacientes.CRReporteGralPacientes();
            pacientes.SetDatabaseLogon(Clases.Entorno.USER, Clases.Entorno.PWD);
            CrvReporteGeneral.ReportSource = pacientes;
        }

        private void CrvReporteGeneral_Load(object sender, EventArgs e)
        {

        }
    }
}
