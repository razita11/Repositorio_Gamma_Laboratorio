using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLaboratorio.Clases
{
    internal class Auth
    {
        Clases.DB db = new Clases.DB();
        Clases.Helpers h = new Clases.Helpers();

        public static string USERNAME;
        public static string ROL;
        public static string NOMBRE;
        public static string GUARDAR;
        public static string ACTUALIZAR;
        public static string ELIMINAR;
        public static string IMPRIMIR;
        public static string REIMPRIMIR;

        public bool RegisterUserAdmin()
        {
            bool resp = false;

            if (db.Exists("USUARIOS", "USERNAME", $"'EFuentes'") == false)
            {
                string username, clave, nombre, genero, fechanac, correo;
                username = "EFuentes";
                clave = BCrypt.Net.BCrypt.HashPassword("12345678");
                nombre = "Nazareth Enmanuel Fuentes Bautista";
                genero = "Hombre";
                fechanac = "05/10/2001";
                correo = "enmanuelfuentes794@gmail.com";

                string campos = "USERNAME, CLAVE, NOMBRE, GENERO, FECHA_NAC, CORREO";
                string valores = $"'{username}','{clave}','{nombre}','{genero}','{fechanac}','{correo}'";
                db.Save("USUARIOS", campos, valores);
            }

            return resp;
        }

        public bool makeLogin(string username, string clave)
        {
            bool resp = false;
            DataTable data = db.Find("USUARIOS", "*", $"USERNAME='{username}'");

            if (data.Rows.Count > 0)
            {
                DataRow infouser = data.Rows[0];
                string usuario = infouser["USERNAME"].ToString();
                string clave_db = infouser["CLAVE"].ToString();
                string estado = infouser["ESTADO"].ToString();

                USERNAME = usuario;
                ROL = infouser["ROL"].ToString();
                NOMBRE = infouser["NOMBRE"].ToString();
                if (username == usuario && BCrypt.Net.BCrypt.Verify(clave, clave_db) && estado == "ACTIVO")
                {
                    h.Success($"Bienvenido'{usuario}'");
                    resp = true;

                }
                else
                {
                    h.advertencia("Las credenciales parecen no ser Correctas");
                }

            }
            else
            {
                h.advertencia("Usuario No Existe!");
            }
            return resp;
        }

        public string ObtenerUsuarioSesion()
        {
            return Auth.USERNAME;
        }

    }
}
