using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MvcMovie.Models
 {
    class Login
    {
        static bool LoginWithData(string usernameString, string passwordString)
        {
        string? GottenUsername = null;
        string? GottenPassword = null;
            bool result = false;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "<your_server.database.windows.net>";
                builder.UserID = "<your_username>";
                builder.Password = "<your_password>";
                builder.InitialCatalog = "<your_database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT username, password FROM USER WHERE username = @username";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@username", SqlDbType.VarChar);
                        command.Parameters["@username"].Value = usernameString;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                                GottenUsername = reader.GetString(0);
                                GottenPassword = reader.GetString(1);
                            }
                        }
                    }
                }
                if (GottenPassword == passwordString)
                { 
                    result = true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Username Not found");
            }
            return result;
        }
    }
}
