using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace MvcMovie.Models
{
    public class DisplayItems
    {
        /**
         * Returns a list of products, sorted by 
         * "dateHarvested"
         */
        public static List<Product> getAllItems() 
        {
            List<Product> allProducts = new List<Product>();
            SqlConnection? connection = Database.ConnectToDatabase();
            String sql = "SELECT itemId, name, dimensions, farmerId, weight, dateGrown, dateHarvested, image FROM Item ORDER BY dateHarvested";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product currentProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString(), decimal.ToDouble(reader.GetDecimal(4)), reader.GetDateTime(5).ToString(), reader.GetDateTime(6).ToString(), reader.GetString(7));
                        allProducts.Add(currentProduct);
                    }
                }
            }
            connection.Close();
            return allProducts;
        }
    }
}
