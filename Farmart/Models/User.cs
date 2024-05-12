using System.Net.Sockets;namespace Farmart.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class User(string userName, string password, string email, string firstName, string lastName) : IUser
{
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
    public string Email { get; set; } = email;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;

    /**
     * Checks if the username or email already exists and if it does returns falses, if not it adds it to the database and returns true
     */
    public bool RegisterUser()
    {
        bool result = false;
        SqlConnection? connection = Database.ConnectToDatabase();

        // Check if username or email already exist
        string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
        {
            checkCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = UserName;
            checkCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;

            int count = (int)checkCommand.ExecuteScalar();
            if (count > 0)
            {
                // Username or email already exists
                result = false;
                Database.CloseConnection(connection);
                return result;
            }
        }

        // If username and email are unique, proceed with user registration
        string insertQuery = "INSERT INTO users (username, firstName, lastName, email, password) VALUES (@username, @firstName, @lastName, @email, @password);";
        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@firstName", SqlDbType.VarChar).Value = FirstName;
            command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = LastName;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // User registered successfully
                result = true;
            }
        }

        Database.CloseConnection(connection);
        return result;
    }

    public void changePassword(string newPassword) 
    {
        this.Password = newPassword;
    }

    public void changeEmail(string newEmail)
    {
        this.Email = newEmail;
    }

    public void changeFirstName(string newFirstName)
    {
        this.FirstName = newFirstName;
    }

    public void changeLastName(string newLastName)
    {
        this.LastName = newLastName;
    }
}