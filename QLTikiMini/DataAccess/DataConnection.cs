using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataConnection
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = "Server=.;Database=QLTIKIMINI;Integrated Security=true;";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
