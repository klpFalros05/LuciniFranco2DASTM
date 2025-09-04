using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tp2FrancoLucni
{
    public class Verificador
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Tp2DasCrud;Integrated Security=True" +
            "user= FrancoL";

        public bool ok()
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
