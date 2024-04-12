namespace MvcMovie.Models;
public class Customers : Users
{
    public Customers(string userName, string password, int userId, string email, string firstName, string lastName, int customerId, string address)
        : base(userName, password, userId, email, firstName, lastName)
    {
        CustomerId = customerId;
        Address = address;
    }
    public int CustomerId { get; set; }

    public string Address { get; set; }
}