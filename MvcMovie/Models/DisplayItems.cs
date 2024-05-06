using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace MvcMovie.Models
{
    public class DisplayItems
    {
        /**
         * Returns a list of products, sorted by @sortedBy
         * This variable can be any column some examples include
         * "name"
         * "dateGrown"
         * "dateHarvested"
         */
        public static List<Product> getAllItems(string sortedBy)
        {
            List<Product> allProducts = new List<Product>();
            SqlConnection? connection = Database.ConnectToDatabase();
            String sql = "SELECT * FROM Item ORDER BY @sort";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@sort", SqlDbType.VarChar).Value = sortedBy;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product currentProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetFloat(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                        allProducts.Add(currentProduct);
                    }
                }
            }
            connection.Close();
            return allProducts;
        }
    }
}
