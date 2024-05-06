namespace MvcMovie.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }
        public string DateGrown { get; set; }
        public string DateHarvested { get; set; }
        public string ImageURL { get; set; }

        public Product(int productId, string name, string description, string category, double weight, string dateGrown, string dateHarvested, string imageURL)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Category = category;
            Weight = weight;
            DateGrown = dateGrown;
            DateHarvested = dateHarvested;
            ImageURL = imageURL;
        }
    }
}

