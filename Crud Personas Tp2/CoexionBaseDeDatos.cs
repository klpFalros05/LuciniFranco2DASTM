using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Crud_Personas_Tp2
{
    public class CoexionBaseDeDatos
    {
        private SqlConnection conexion;

        private string connectionString
            = "Data source=localhost;Initial Catalog=Tp 2 Das";

        public bool verificacion()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }
        return true;
        }
    }

}