using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace MvcMovie.Models
 {
    public class SignIn
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public static bool LoginWithData(string usernameString, string passwordString)
        {
        string? GottenUsername = null;
        string? GottenPassword = null;
        bool result = false;
            try
            {
                string connectionStr = "Data Source=localhost\\sqlexpress;Initial Catalog = master; Integrated Security=True; MultipleActiveResultSets=True; TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionStr))
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
                                GottenUsername = reader.GetString(0);
                                GottenPassword = reader.GetString(1);
                                connection.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (GottenUsername == usernameString && GottenPassword == passwordString)
            {
                result = true;
            }
            return result;
        }

        public static User? getUserFromDatabase(string UserName)
        {
            SqlConnection? connection = Database.ConnectToDatabase();
            String sql = "SELECT username, password, email, firstname, lastname FROM Users WHERE username = @username";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@username", SqlDbType.VarChar);
            command.Parameters["@username"].Value = UserName;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4));
                    Database.CloseConnection(connection);
                    return user;
                }
            }
            return null;
        }
    }
}
