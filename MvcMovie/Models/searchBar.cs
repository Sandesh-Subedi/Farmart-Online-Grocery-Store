using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MvcMovie.Models
{
    public static class SearchBar
    {
        // This function searches the products in the database based on the provided search term.
        public static List<Product> SearchProducts(string searchTerm)
        {
            List<Product> foundProducts = new List<Product>();
            SqlConnection? connection = Database.ConnectToDatabase();

            try
            {
                string sql = "SELECT * FROM Product WHERE name LIKE @search OR category LIKE @search";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@search", SqlDbType.VarChar).Value = $"%{searchTerm}%";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(
                                reader.GetInt32(0), // productId
                                reader.GetString(1), // name
                                reader.GetString(2), // description
                                reader.GetString(3), // category
                                reader.GetDouble(4), // weight
                                reader.GetString(5), // dateGrown
                                reader.GetString(6), // dateHarvested
                                reader.GetString(7)); // imageURL
                            foundProducts.Add(product);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error during database operation: " + e.Message);
            }
            finally
            {
                Database.CloseConnection(connection);
            }

            return foundProducts;
        }
    }
}
