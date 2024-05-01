using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MvcMovie.Models
 {
    public class SignIn
    {
        public static bool LoginWithData(string usernameString, string passwordString)
        {
        string? GottenUsername = null;
        string? GottenPassword = null;
        bool result = false;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "cse.unl.edu";
                builder.UserID = "yorazov";
                builder.Password = "E7hAh164";
                builder.InitialCatalog = "yorazov";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT username, password FROM Users WHERE username = @username";

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
