namespace MvcMovie.Models;

public class Cart(int cartId, int quantity, List<Product> products)
{
    public int CartId { get; set; } = cartId;
    public int Quantity { get; set; } = quantity;
    public List<Product> Products { get; set; } = products;
}