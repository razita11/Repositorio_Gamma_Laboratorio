using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLaboratorio.Clases
{
    internal class SQLServer : Clases.Entorno
    {
        Clases.Helpers h = new Clases.Helpers();
        public static string cadena_conexion_sql;
        public static SqlConnection ConSQL = new SqlConnection();
        public void actualizarConexionSQLServer()
        {
            cadena_conexion_sql = $"Server={SERVER};Database={DATABASE};User Id={USER} ;Pwd={PWD}";
            ConSQL = new SqlConnection(cadena_conexion_sql);
        }

        public void abrirConexion()
        {
            try
            {
                ConSQL.Open();
            }
            catch (SqlException error)
            {
                h.advertencia(error.Message);
            }
        }

        public void cerrarConexion()
        {
            try
            {
                ConSQL.Close();
            }
            catch (SqlException error)
            {
                h.advertencia(error.Message);
            }
        }

        public void terminarConexion()
        {
            ConSQL.Close();

        }
    }
}
