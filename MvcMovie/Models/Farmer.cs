namespace MvcMovie.Models;
public class Farmers(
    string userName,
    string password,
    int userId,
    string email,
    string firstName,
    string lastName,
    int farmerId,
    bool verification)
    : Users(userName, password, userId, email, firstName, lastName)
{
    public int FarmerId { get; set;} = farmerId;

    public bool Verification { get; set; } = verification;
}