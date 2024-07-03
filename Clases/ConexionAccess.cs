using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLaboratorio.Clases
{
    internal class ConexionAccess
    {
        Clases.Helpers h = new Clases.Helpers();
        public static string cadena_conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DataSistema\CONFIGURACIONLAB.accdb;Jet OLEDB:Database Password=RAZIta11;";
        public static OleDbConnection ConAccess = new OleDbConnection(cadena_conexion);

        public void abrirConexion()
        {
            try
            {
                ConAccess.Open();
            }
            catch (OleDbException error)
            {
                h.advertencia(error.Message);
            }
        }

        public void cerrarConexion()
        {
            try
            {
                ConAccess.Close();
            }
            catch (OleDbException error)
            {
                h.advertencia(error.Message);
            }
        }

        public void TerminarConexion()
        {
            if (ConAccess.State == ConnectionState.Open)
            {
                ConAccess.Close();
            }
        }
    }
}
