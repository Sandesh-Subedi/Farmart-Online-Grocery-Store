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
                string sql = "SELECT * FROM Item WHERE name LIKE @search OR category LIKE @search";  // Corrected from Product to Item based on your DB schema

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@search", SqlDbType.VarChar).Value = $"%{searchTerm}%";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double weight;
                            // Check if the data type of the weight column is decimal or not and handle accordingly
                            if (reader.GetFieldType(7) == typeof(decimal)) // Adjust the index if necessary
                            {
                                weight = Convert.ToDouble(reader.GetDecimal(7)); // Get weight as decimal and convert to double
                            }
                            else if (reader.GetFieldType(7) == typeof(int))
                            {
                                weight = reader.GetInt32(7); // Get weight as int and treat it as double
                            }
                            else
                            {
                                throw new InvalidCastException("Unexpected data type for weight.");
                            }

                            Product product = new Product(
                                reader.GetInt32(0), // productId
                                reader.GetString(1), // name
                                reader.GetString(2), // description
                                reader.GetString(3), // category
                                weight,
                                reader.GetString(5), // dateGrown
                                reader.GetString(6), // dateHarvested
                                reader.GetString(4)); // imageURL, corrected index to match your schema
                            foundProducts.Add(product);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error during database operation: {e.Message}");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"Data type mismatch when retrieving data: {e.Message}");
            }
            finally
            {
                Database.CloseConnection(connection);
            }

            return foundProducts;
        }
    }
}








// using Microsoft.Data.SqlClient;
// using System;
// using System.Collections.Generic;
// using System.Data;

// namespace MvcMovie.Models
// {
//     public static class SearchBar
//     {
//         // This function searches the products in the database based on the provided search term.
//         public static List<Product> SearchProducts(string searchTerm)
//         {
//             List<Product> foundProducts = new List<Product>();
//             SqlConnection? connection = Database.ConnectToDatabase();

//             try
//             {
//                 string sql = "SELECT * FROM Product WHERE name LIKE @search OR category LIKE @search";

//                 using (SqlCommand command = new SqlCommand(sql, connection))
//                 {
//                     command.Parameters.Add("@search", SqlDbType.VarChar).Value = $"%{searchTerm}%";

//                     using (SqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             Product product = new Product(
//                                 reader.GetInt32(0), // productId
//                                 reader.GetString(1), // name
//                                 reader.GetString(2), // description
//                                 reader.GetString(3), // category
//                                 Convert.ToDouble(reader.GetDecimal(4)), // weight converted from decimal to double
//                                 reader.GetString(5), // dateGrown
//                                 reader.GetString(6), // dateHarvested
//                                 reader.GetString(7)); // imageURL
//                             foundProducts.Add(product);
//                         }
//                     }
//                 }
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine("Error during database operation: " + e.Message);
//             }
//             finally
//             {
//                 Database.CloseConnection(connection);
//             }

//             return foundProducts;
//         }
//     }
// }
