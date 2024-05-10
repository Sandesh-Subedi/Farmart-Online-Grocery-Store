namespace Farmart.Models
{
    public class Product(
        int productId,
        string name,
        string description,
        string category,
        double price,
        string dateGrown,
        string dateHarvested,
        string imageURL)
    {
        public int ProductId { get; set; } = productId;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Category { get; set; } = category;
        public double Price { get; set; } = price;
        public string DateGrown { get; set; } = dateGrown;
        public string DateHarvested { get; set; } = dateHarvested;
        public string ImageURL { get; set; } = imageURL;

    }
}
