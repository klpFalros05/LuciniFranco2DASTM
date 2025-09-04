using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tp_2_Crud__Empleados_
{
    internal class ConeccionBaseDatos
    {
        private SqlConnection coneccion;

        private string connectionString
            = "Server=LAPTOP-IQ10BU3N\\SQLEXPRESS01;" +
    "Database=[Tp 2 Das];" +   // base con espacios, por eso entre []
    "Integrated Security=True;" +
    "Encrypt=True;TrustServerCertificate=True;";

        public bool verificacion(out string error)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                    conn.Open();

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.ToString();   // para ver el motivo real
                return false;
            }
        }
    }
}

