namespace MvcMovie.Models;
public class Customers : User
{
    public Customers(string userName, string password, string email, string firstName, string lastName, int customerId, string address)
        : base(userName, password, email, firstName, lastName)
    {
        CustomerId = customerId;
        Address = address;
    }
    public int CustomerId { get; set; }

    public string Address { get; set; }
}