using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace MvcMovie.Models
 {
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public DateTime DateOfBirth { get; set; }
        
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
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
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
    }
}
