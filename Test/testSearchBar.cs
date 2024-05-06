using NUnit.Framework;
using MvcMovie.Models;
using System.Collections.Generic;

namespace MvcMovie.Tests
{
    [TestFixture]
    public class TestSearchBar
    {
        private SqlConnection? _connection;

        [SetUp]
        public void Setup()
        {
            // Connect to the test database before each test.
            _connection = Database.ConnectToDatabase();
        }

        [Test]
        public void TestSearchProductsReturnsResults()
        {
            // Test the search functionality with a known value that should return results
            var products = SearchBar.SearchProducts("Apple");
            Assert.IsTrue(products.Count > 0, "No products found matching 'Apple'");
        }

        [Test]
        public void TestSearchProductsWithNoResults()
        {
            // Test the search functionality with a value known to produce no results
            var products = SearchBar.SearchProducts("NonExistentProduct");
            Assert.AreEqual(0, products.Count, "Products should not be found for 'NonExistentProduct'");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the database connection after each test.
            if (_connection != null)
            {
                Database.CloseConnection(_connection);
            }
        }
    }
}
