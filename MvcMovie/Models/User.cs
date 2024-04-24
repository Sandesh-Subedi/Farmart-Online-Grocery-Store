using System.Net.Sockets;namespace MvcMovie.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class User(string userName, string password, string email, string firstName, string lastName) : IUser
{
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
    public string Email { get; set; } = email;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;

    public void RegisterUser() 
    {
        SqlConnection? connection = Database.ConnectToDatabase();
        String sql = "SELECT username, password FROM Users WHERE username = @username";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.Add("@username", SqlDbType.VarChar);
            command.Parameters["@username"].Value = UserName;
            using (SqlDataReader reader = command.ExecuteReader())
                Database.CloseConnection(connection);
        }
        throw new NotImplementedException();
    }

    public void changePassword() 
    {
        throw new NotImplementedException();
    }

    public void changeEmail()
    {
        throw new NotImplementedException();
    }

    public void changeFirstName()
    {
        throw new NotImplementedException();
    }

    public void changeLastName()
    {
        throw new NotImplementedException();
    }
}