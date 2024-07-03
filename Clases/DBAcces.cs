using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLaboratorio.Clases
{
    internal class DBAcces : Clases.ConexionAccess
    {
        Clases.Helpers h = new Clases.Helpers();
        OleDbCommand com;
        OleDbDataReader reader;
        DataTable recordset;
        string query;

        public DataTable Find(string tabla)
        {
            recordset = new DataTable();
            query = $"SELECT * FROM {tabla}";
            try
            {
                com = new OleDbCommand(query, ConAccess);
                abrirConexion();
                reader = com.ExecuteReader();
                recordset.Load(reader);

                reader.Close();
                com.Dispose();
                cerrarConexion();
            }
            catch (OleDbException error)
            {
                h.advertencia(error.Message);
            }
            finally
            {
                TerminarConexion();
            }
            return recordset;
        }
    }
}
