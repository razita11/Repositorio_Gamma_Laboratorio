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
    public partial class FrmLogin : Form
    {
        Clases.BootStrapper bs = new Clases.BootStrapper();
        Clases.Helpers helpers = new Clases.Helpers();
        Clases.Auth auth = new Clases.Auth();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            {
                if (bs.revisarArchivosConfig() == true)
                {
                    if (bs.revisarInfoArchivoConfiguracion() == true)
                    {
                        auth.RegisterUserAdmin();
                    }
                }
                else
                {
                    MessageBox.Show("ERROR AL CARGAR EL ARCHIVO DE CONFIGURACION");
                    Application.Exit();
                }
            }

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text.Trim();
            string clave = TxtContraseña.Text.Trim();

            if (auth.makeLogin(username, clave) == true)
            {
                //Vistas.FrmMenu menu = new Vistas.FrmMenu();
                Vistas.FrmMenu menu = new Vistas.FrmMenu();
                menu.Show();
                //menu.Show();
                this.Hide();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
