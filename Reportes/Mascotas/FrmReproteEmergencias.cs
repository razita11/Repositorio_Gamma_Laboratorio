using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Reportes.Mascotas
{
    public partial class FrmReproteEmergencias : Form
    {
        public FrmReproteEmergencias()
        {
            InitializeComponent();
        }

        private void FrmReproteEmergencias_Load(object sender, EventArgs e)
        {
            Reportes.Mascotas.CRReporteGralMascotas reporte = new Reportes.Mascotas.CRReporteGralMascotas();
            reporte.SetDatabaseLogon(Clases.Entorno.USER, Clases.Entorno.PWD);
            CrvReporGralEmer.ReportSource = reporte;
        }
    }
}
