using Microsoft.Data.SqlClient;

namespace Farmart.Models;

public class Cart (int cartId)
{
    public int CartId { get; set; } = cartId;
    public int Quantity { get; set; } = 0;
    public List<Product> Products { get; set; } = [];
    public override string ToString()
    {
        string cartString = "Product\tQuantity\tPrice\tPriceTotal\n";
        foreach (Product p in Products)
        {
            cartString += p.ToString();
        }
        cartString += GetCartTotal();
        return cartString;
    }
    public double GetCartTotal()
    {
        double cartTotal = 0.0;
        foreach (Product p in Products)
        {
            cartTotal += p.Price;
        }
        return cartTotal;
    }

    public void AddItem(Product p, int numberOfItems)
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            Products.Add(p);
            Quantity++;
        }
    }
    public void RemoveItem(Product product, int numberOfItems)
    {
        var itemsToRemove = Products.Where(p => p.Equals(product)).Take(numberOfItems).ToList();
        foreach (var itemToRemove in itemsToRemove)
        {
            Products.Remove(itemToRemove);
        }
        Quantity -= itemsToRemove.Count;
    }

    public void ClearCart()
    {
        Products.Clear();
        Quantity = 0;
    }

    public Product GetProductById(int productId)
    {
        return Products.Find(p => p.ProductId == productId);
    }

    public void GetCartFromDatabase(Cart newCart, int newCartId, int userId)
    {
        SqlConnection? connection = Database.ConnectToDatabase();
        string query = "SELECT CartId, UserId, FROM Cart WHERE CartId = @CartId";

        using (connection)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CartId", newCartId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newCartId = reader.GetInt32(0);
                    userId = reader.GetInt32(1);
                    newCart = new Cart(newCartId);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}