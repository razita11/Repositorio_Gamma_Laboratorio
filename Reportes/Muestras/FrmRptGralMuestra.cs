using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Reportes.Muestras
{
    public partial class FrmRptGralMuestra : Form
    {
        public FrmRptGralMuestra()
        {
            InitializeComponent();
        }

        private void FrmRptGralMuestra_Load(object sender, EventArgs e)
        {
            Reportes.Muestras.CRReporteGralMuestras cRReporte = new Reportes.Muestras.CRReporteGralMuestras();
            cRReporte.SetDatabaseLogon(Clases.Entorno.USER, Clases.Entorno.PWD);
            CrvGralMuestra.ReportSource = cRReporte;
        }

        private void CrvGralMuestra_Load(object sender, EventArgs e)
        {

        }
    }
}
