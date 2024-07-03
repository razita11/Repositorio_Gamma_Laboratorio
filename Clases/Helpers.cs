using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLaboratorio.Clases
{
    internal class Helpers
    {
        // Propiedades para los botones de las alertas

        MessageBoxButtons botones;
        MessageBoxIcon icono;

        public void advertencia(string msg_advertencia)
        {
            botones = MessageBoxButtons.OK;
            icono = MessageBoxIcon.Warning;
            MessageBox.Show(msg_advertencia, "Advertencia", botones, icono);
        }

        public void Success(string msg)
        {
            botones = MessageBoxButtons.OK;
            icono = MessageBoxIcon.Information;
            MessageBox.Show(msg, "Exito", botones, icono);

        }

        public bool Question(string msg)
        {
            bool resp = false;
            botones = MessageBoxButtons.YesNo;
            icono = MessageBoxIcon.Question;
            if (MessageBox.Show(msg, "Confirmar", botones, icono) == DialogResult.Yes)
            {
                resp = true;
            }
            return resp;
        }
    }
}
