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
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "cse.unl.edu";
                builder.UserID = "yorazov";
                builder.Password = "E7hAh164";
                builder.InitialCatalog = "yorazov";

                connection = new SqlConnection(builder.ConnectionString);
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
