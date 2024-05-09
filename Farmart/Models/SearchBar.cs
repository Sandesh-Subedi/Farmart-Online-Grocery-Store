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
                string sql = "SELECT itemId, name, dimensions, farmerId, weight, dateGrown, dateHarvested, image FROM Item WHERE name LIKE @search";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@search", SqlDbType.VarChar).Value = $"%{searchTerm}%";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString(), decimal.ToDouble(reader.GetDecimal(4)), reader.GetDateTime(5).ToString(), reader.GetDateTime(6).ToString(), reader.GetString(7));
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
