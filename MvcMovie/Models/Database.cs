using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Data;

namespace MvcMovie.Models
 {
    public class Database
    {
        public static SqlConnection ConnectToDatabase()
        {
            SqlConnection? connection = null;
            try
            {
                string connectionStr = "Data Source=localhost\\sqlexpress;Initial Catalog = master; Integrated Security=True; MultipleActiveResultSets=True; TrustServerCertificate=True;";

                connection = new SqlConnection(connectionStr);
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return connection;
        }

        public static void CloseConnection(SqlConnection connection) 
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed) 
            { 
                connection.Close();
            }
        }
    }
}
