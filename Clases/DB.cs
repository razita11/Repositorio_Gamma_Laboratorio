using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ProyectoLaboratorio.Clases
{
    internal class DB:Clases.SQLServer
    {
        Clases.Helpers h = new Clases.Helpers();
        SqlCommand com;
        SqlDataReader reader;
        DataTable data;
        DataTable recordset;
        string query;

        public bool Save(string tablename, string campos, string valores)
        {
            query = $"INSERT INTO {tablename}({campos}) VALUES ({valores})";
            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                int rowsAffected = com.ExecuteNonQuery();
                return rowsAffected > 0; // Retorna verdadero si rowsAffected es mayor que cero, falso en caso contrario
            }
            catch (SqlException error)
            {
                h.advertencia(error.Message);
                return false; // En caso de error, retornamos falso
            }
            finally
            {
                cerrarConexion();
            }
        }



        public DataTable Find(string tablename, string campos, string condicion = "", string orderby = "", bool debug = false)
        {
            recordset = new DataTable();
            if (condicion == "" && orderby == "")
            {
                query = $"SELECT {campos} FROM {tablename}";

            }
            else if (condicion != "" && orderby == "")
            {
                query = $"SELECT {campos} FROM {tablename} WHERE {condicion}";
            }
            else if (condicion == "" && orderby != "")
            {
                query = $"SELECT {campos} FROM {tablename} ORDER BY {orderby}";
            }
            else if (condicion != "" && orderby != "")
            {
                query = $"SELECT {campos} FROM {tablename} WHERE {condicion} ORDER BY {orderby}";
            }

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                reader = com.ExecuteReader();
                recordset.Load(reader);
                reader.Close();
                com.Dispose();
                cerrarConexion();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al Recuperar Datos{error}");
            }

            finally
            {
                terminarConexion();
            }
            return recordset;
        }

        public bool Exists(string tablename, string campo, string value)
        {
            bool resp = false;
            query = $"SELECT * FROM {tablename} WHERE {campo}={value}";
            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    resp = true;
                }
                reader.Close();
                com.Dispose();
            }
            catch (SqlException error)
            {
                h.advertencia(error.Message);
            }
            finally
            {
                terminarConexion();
            }

            return resp;
        }

        public int Destroy(string tablename, string condicion = "")
        {
            int rd = 0;
            if (condicion == "")
            {
                query = $"DELETE FROM {tablename}";
            }
            else
            {
                query = $"DELETE FROM {tablename} WHERE {condicion}";
            }
            rd = rawSQL(query);
            return rd;
        }

        private int rawSQL(string _query)
        {
            int ra = 0;
            try
            {
                com = new SqlCommand(_query, ConSQL);
                abrirConexion();
                ra = com.ExecuteNonQuery();
                cerrarConexion();
                com.Dispose();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                terminarConexion();
            }
            return ra;
        }

        public int update(string tablename, string data, string condicion = "")
        {
            int ru = 0;
            if (condicion == "")
            {
                query = $"UPDATE {tablename} SET {data}";
            }
            else
            {
                query = $"UPDATE {tablename} SET {data} WHERE {condicion}";
            }

            ru = rawSQL(query);

            return ru;
        }
        public string ObtenerNombrePaciente(string dni)
        {
            string nombre = string.Empty;
            query = $"SELECT NOMBRE FROM PACIENTES WHERE DNI = @dni";
            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@dni", dni);
                abrirConexion();
                nombre = com.ExecuteScalar()?.ToString();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el nombre del paciente: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }
            return nombre;
        }

        public string ObtenerApellidoPaciente(string dni)
        {
            string apellido= string.Empty;
            query = $"SELECT APELLIDOS FROM PACIENTES WHERE DNI = @dni";
            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@dni", dni);
                abrirConexion();
                apellido = com.ExecuteScalar()?.ToString();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el apellido del paciente: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }
            return apellido;
        }

        public string ObtenerNombrePacienteEnPrueba(string muestraId)
        {
            string nombre = string.Empty;
            query = $"SELECT PACIENTES.NOMBRE " +
                    $"FROM PACIENTES " +
                    $"INNER JOIN MUESTRAS ON PACIENTES.DNI = MUESTRAS.DNI_PACIENTE " +
                    $"WHERE MUESTRAS.MUESTRA_ID = @muestraId";

            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@muestraId", muestraId);
                abrirConexion();
                nombre = com.ExecuteScalar()?.ToString();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el nombre del paciente: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }
            return nombre;
        }


        public string ObtenerNombreMuestra(string id)
        {
            string muestra = string.Empty;
            query = $"SELECT TIPO_MUESTRA FROM MUESTRAS WHERE MUESTRA_ID=@id";
            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@id", id);
                abrirConexion();
                muestra = com.ExecuteScalar()?.ToString();
            }
            catch(SqlException error)
            {
                h.advertencia($"Error al Obtener el id de la muestra: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }
            return muestra;
        }

        public string GetLastMuestraId()
        {
            string lastMuestraId = string.Empty;
            query = "SELECT TOP 1 MUESTRA_ID FROM MUESTRAS ORDER BY MUESTRA_ID DESC";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    lastMuestraId = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el último ID de muestra: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return lastMuestraId;
        }

        public string GetLastEmergenciaId()
        {
            string lastEmergencia = string.Empty;
            query = "SELECT TOP 1 ID FROM EMERGENCIAS ORDER BY ID DESC";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    lastEmergencia = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el último ID de Emergencia: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return lastEmergencia;
        }
        public class Mascota
        {
            public string Nombre { get; set; }
            public string Especie { get; set; }
        }

        public Mascota ObtenerDatosMascota(string codigo)
        {
            Mascota mascota = null;
            string nombre = string.Empty;
            string especie = string.Empty;
            query = $"SELECT NOMBRE, ESPECIE FROM MASCOTAS WHERE CODIGO = @codigo";
            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@codigo", codigo);
                abrirConexion();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    nombre = reader["NOMBRE"].ToString();
                    especie = reader["ESPECIE"].ToString();
                    mascota = new Mascota { Nombre = nombre, Especie = especie };
                }
                reader.Close();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener los datos de la Mascota: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }
            return mascota;
        }
        public string GetLastCitaId()
        {
            string lastMuestraId = string.Empty;
            query = "SELECT TOP 1 CITA_ID FROM CITAS ORDER BY CITA_ID DESC";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    lastMuestraId = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el último ID de cita: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return lastMuestraId;
        }

        public string ObtenerNombreApellidoPaciente(string dni)
        {
            string nombreApellido = "";
            string query = $"SELECT NOMBRE, APELLIDOS FROM PACIENTES WHERE DNI = '{dni}'";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    string nombre = reader["NOMBRE"].ToString();
                    string apellidos = reader["APELLIDOS"].ToString();
                    nombreApellido = $"{nombre} {apellidos}";
                }

                reader.Close();
                com.Dispose();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener nombre y apellido del paciente: {error.Message}");
            }
            finally
            {
                terminarConexion();
            }

            return nombreApellido;
        }

        public string GetLastPruebaId()
        {
            string lastPruebaId = string.Empty;
            query = "SELECT TOP 1 PRUEBA_ID FROM PRUEBAS ORDER BY PRUEBA_ID DESC";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    lastPruebaId = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el último ID de prueba: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return lastPruebaId;
        }

        public DataTable FindMuestrasYPruebasPendientes(string dni)
        {
            recordset = new DataTable();
            query = @"SELECT M.MUESTRA_ID AS ID, M.CODIGO AS Codigo, 
                     CONCAT(M.TIPO_MUESTRA, ' - Muestra') AS Servicios, 
                     M.PRECIO AS Precio, 
                     M.USUARIO AS Usuario
              FROM MUESTRAS M
              WHERE M.DNI_PACIENTE = @dni AND M.ESTADO = 'PENDIENTE'
              UNION ALL
              SELECT P.PRUEBA_ID AS ID, P.CODIGO AS Codigo, 
                     CONCAT(P.TIPO_PRUEBA, ' - Prueba') AS Servicios, 
                     P.PRECIO AS Precio, 
                     P.USUARIO AS Usuario
              FROM PRUEBAS P
              INNER JOIN MUESTRAS M ON P.MUESTRA_ID = M.MUESTRA_ID
              WHERE M.DNI_PACIENTE = @dni AND P.ESTADO = 'PENDIENTE'";

            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@dni", dni);
                abrirConexion();
                reader = com.ExecuteReader();
                recordset.Load(reader);
                reader.Close();
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al recuperar muestras y pruebas pendientes: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return recordset;
        }

        public string ObtenerNombreCompletoPaciente(string dni)
        {
            string nombreCompleto = string.Empty;
            query = $"SELECT CONCAT(NOMBRE, ' ', APELLIDOS) AS NombreCompleto FROM PACIENTES WHERE DNI = @dni";

            try
            {
                com = new SqlCommand(query, ConSQL);
                com.Parameters.AddWithValue("@dni", dni);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    nombreCompleto = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el nombre completo del paciente: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return nombreCompleto;
        }

        public string GetLastFacturaId()
        {
            string lastPruebaId = string.Empty;
            query = "SELECT TOP 1 FACTURA_ID FROM FACTURAS ORDER BY FACTURA_ID DESC";

            try
            {
                com = new SqlCommand(query, ConSQL);
                abrirConexion();
                object result = com.ExecuteScalar();
                if (result != null)
                {
                    lastPruebaId = result.ToString();
                }
            }
            catch (SqlException error)
            {
                h.advertencia($"Error al obtener el último ID de la factura: {error.Message}");
            }
            finally
            {
                cerrarConexion();
            }

            return lastPruebaId;
        }
        public bool ActualizarEstadoServiciosPagados(string dni)
        {  
             try
             {
                // Actualizar el estado de las muestras
                string queryMuestras = $"UPDATE MUESTRAS SET ESTADO = 'PAGADO' WHERE DNI_PACIENTE = '{dni}' AND ESTADO = 'PENDIENTE'";
                 com = new SqlCommand(queryMuestras, ConSQL);
                abrirConexion();
                int rowsAffectedMuestras = com.ExecuteNonQuery();

                 // Actualizar el estado de las pruebas
                string queryPruebas = $"UPDATE PRUEBAS SET ESTADO = 'PAGADO' WHERE MUESTRA_ID IN (SELECT MUESTRA_ID FROM MUESTRAS WHERE DNI_PACIENTE = '{dni}' AND ESTADO = 'PAGADO')";
                com = new SqlCommand(queryPruebas, ConSQL);
                int rowsAffectedPruebas = com.ExecuteNonQuery();

                // Comprobar si al menos una de las consultas afectó filas
                return rowsAffectedMuestras > 0 || rowsAffectedPruebas > 0;
             }
             catch (SqlException error)
             {
                h.advertencia($"Error al actualizar el estado de los servicios: {error.Message}");
                return false;
             }
             finally
             {
                cerrarConexion();
             }
        }
        
        public void print (ReportDocument reporte)
        {
            try
            {
                ConnectionInfo con = new ConnectionInfo();
                Tables _tables = reporte.Database.Tables;
                con.ServerName = Clases.Entorno.SERVER;
                con.DatabaseName = Clases.Entorno.DATABASE;
                con.UserID = Clases.Entorno.USER;
                con.Password = Clases.Entorno.PWD;

                foreach (CrystalDecisions.CrystalReports.Engine.Table _table in _tables)
                {
                    TableLogOnInfo loginfo = _table.LogOnInfo;
                    loginfo.ConnectionInfo = con;
                    _table.ApplyLogOnInfo(loginfo);
                }
            }
            catch (CrystalReportsException error )
            {
                h.advertencia(error.Message);
            }
            finally
            {
                terminarConexion();
            }
        }

    }
}
