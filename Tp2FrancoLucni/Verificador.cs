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
        private string connectionString = "Data Source=LAPTOP-IQ1OBU3N\\SQLEXPRESS;Initial Catalog=Tp2;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;";

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
