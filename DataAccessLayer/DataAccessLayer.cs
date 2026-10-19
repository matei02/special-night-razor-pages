using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        private string connectionString;

        public DataAccessLayer()
        {
            connectionString = "change-me-to-a-long-random-secret-of-at-least-32-bytes";
        }

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
