using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoLaboratorio.Clases
{
    internal class BootStrapper
    {
        Clases.SQLServer consql = new Clases.SQLServer();
        Clases.Helpers h = new Clases.Helpers();
        Clases.DBAcces dba = new Clases.DBAcces();
        string file_config = @"C:\DataSistema\CONFIGURACIONLAB.accdb";

        public bool revisarArchivosConfig()
        {
            bool resp = false;
            if (File.Exists(file_config))
            {
                resp = true;
            }
            return resp;
        }

        public bool revisarInfoArchivoConfiguracion()
        {
            bool resp = false;
            DataTable data = dba.Find("CONFIG_SERVER");
            if (data.Rows.Count > 0)
            {
                resp = true;
                DataRow info = data.Rows[0];
                Clases.Entorno.SERVER = info["SERVER_NAME"].ToString();
                Clases.Entorno.DATABASE = info["DATABSE_NAME"].ToString();
                Clases.Entorno.USER = info["USER_DB"].ToString();
                Clases.Entorno.PWD = info["USER_PWD"].ToString();
                Clases.Entorno.USER_WINDOWS = info["USER_SO"].ToString();

                consql.actualizarConexionSQLServer();


            }
            else
            {
                h.advertencia("NO SE CARGARON LOS DATOS DEL ARCHIVO DE CONFIGURACION");
            }
            data.Dispose();

            return resp;
        }
    }
}
