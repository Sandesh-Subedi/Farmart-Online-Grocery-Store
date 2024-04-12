using System.Net.Sockets;namespace MvcMovie.Models;

public class Users(string userName, string password, int userId, string email, string firstName, string lastName)
{
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
    public int UserId { get; set; } = userId;
    public string Email { get; set; } = email;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}