namespace Farmart.Models;
public class Farmers(
    string userName,
    string password,
    int userId,
    string email,
    string firstName,
    string lastName,
    int farmerId,
    bool verification)
    : User(userName, password, email, firstName, lastName)
{
    public int FarmerId { get; set;} = farmerId;

    public bool Verification { get; set; } = verification;
}