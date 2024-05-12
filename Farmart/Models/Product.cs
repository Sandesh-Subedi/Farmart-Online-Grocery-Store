using Microsoft.Data.SqlClient;

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
        public void GetProductsFromDatabase(List<Product> products)
        {
            SqlConnection? connection = Database.ConnectToDatabase();
            string query = "SELECT ALL itemId, name, dimensions, farmerId, weight, dateGrown, dateHarvested, image FROM Item";

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Product item = null;
                    while (reader.Read())
                    {
                        item = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetInt32(3).ToString(), decimal.ToDouble(reader.GetDecimal(4)),
                            reader.GetDateTime(5).ToString(), reader.GetDateTime(6).ToString(), reader.GetString(7));
                        products.Add(item);
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
}
