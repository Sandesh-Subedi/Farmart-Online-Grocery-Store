namespace MvcMovie.Models
{
    public class Product(
        int productId,
        string name,
        string description,
        string category,
        double weight,
        string dateGrown,
        string dateHarvested)
    {
        public int ProductId { get; set; } = productId;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public string Category { get; set; } = category;
        public double Weight { get; set; } = weight;
        public string DateGrown { get; set; } = dateGrown;
        public string DateHarvested { get; set; } = dateHarvested;
    }
}
