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
        public void TestSearchWithExactProductName()
        {
            var products = SearchBar.SearchProducts("Organic Apple");
            Assert.IsTrue(products.Count > 0, "Expected results for 'Organic Apple'");
        }

        [Test]
        public void TestSearchWithProductNameCaseInsensitive()
        {
            var products = SearchBar.SearchProducts("organic apple");
            Assert.IsTrue(products.Count > 0, "Expected results for 'organic apple'");
        }

        [Test]
        public void TestSearchWithPartialProductName()
        {
            var products = SearchBar.SearchProducts("Apple");
            Assert.IsTrue(products.Count > 0, "Expected results for partial name 'Apple'");
        }

        [Test]
        public void TestSearchWithNonExistentProduct()
        {
            var products = SearchBar.SearchProducts("XYZ123");
            Assert.AreEqual(0, products.Count, "Expected no results for 'XYZ123'");
        }

        [Test]
        public void TestSearchWithEmptyString()
        {
            var products = SearchBar.SearchProducts("");
            Assert.AreEqual(0, products.Count, "Expected no results for empty search");
        }

        [Test]
        public void TestSearchWithSpecialCharacters()
        {
            var products = SearchBar.SearchProducts("!@#$%");
            Assert.AreEqual(0, products.Count, "Expected no results for '!@#$%'");
        }

        [Test]
        public void TestSearchWithNumericString()
        {
            var products = SearchBar.SearchProducts("123");
            Assert.AreEqual(0, products.Count, "Expected no results for '123'");
        }

        [Test]
        public void TestSearchWithMixedCharacterTypes()
        {
            var products = SearchBar.SearchProducts("Item123");
            Assert.IsTrue(products.Count > 0, "Expected results for 'Item123'");
        }

        [Test]
        public void TestSearchWithWhitespace()
        {
            var products = SearchBar.SearchProducts("   ");
            Assert.AreEqual(0, products.Count, "Expected no results for whitespace");
        }

        [Test]
        public void TestSearchWithSQLInjection()
        {
            var products = SearchBar.SearchProducts("'; DROP TABLE Users; --");
            Assert.AreEqual(0, products.Count, "Expected no results and no harm from SQL injection");
        }

        [Test]
        public void TestSearchReturnsSpecificNumberOfItems()
        {
            var products = SearchBar.SearchProducts("Apple");
            Assert.IsTrue(products.Count == 1, "Expected exactly 1 product for 'Apple'");
        }

        [Test]
        public void TestSearchForItemsByFarmer()
        {
            var products = SearchBar.SearchProducts("John");
            Assert.IsTrue(products.Count > 0, "Expected results for products by farmer 'John'");
        }

        [Test]
        public void TestSearchForMultipleMatchingTerms()
        {
            var products = SearchBar.SearchProducts("Organic Fresh");
            Assert.IsTrue(products.Count > 1, "Expected multiple results for 'Organic Fresh'");
        }

        [Test]
        public void TestSearchForItemByDimensions()
        {
            var products = SearchBar.SearchProducts("3x3x3 inches");
            Assert.IsTrue(products.Count > 0, "Expected results for dimensions '3x3x3 inches'");
        }

        [Test]
        public void TestSearchForItemByDate()
        {
            var products = SearchBar.SearchProducts("2023-04-10");
            Assert.IsTrue(products.Count > 0, "Expected results for date '2023-04-10'");
        }

        [Test]
        public void TestSearchWithUnicodeCharacters()
        {
            var products = SearchBar.SearchProducts("Café");
            Assert.IsTrue(products.Count > 0, "Expected results for 'Café'");
        }

        [Test]
        public void TestSearchForItemByWeight()
        {
            var products = SearchBar.SearchProducts("0.2");
            Assert.IsTrue(products.Count > 0, "Expected results for weight '0.2'");
        }

        [Test]
        public void TestSearchResultsSortedByName()
        {
            var products = SearchBar.SearchProducts("Apple");
            Assert.IsTrue(products[0].Name == "Organic Apple", "Expected 'Organic Apple' to be the first result");
        }

        [Test]
        public void TestSearchResultsIncludeCorrectData()
        {
            var products = SearchBar.SearchProducts("Organic Apple");
            var product = products[0];
            Assert.AreEqual("https://upload.wikimedia.org/wikipedia/commons/1/13/Apple_With_White_Background.jpg", product.Image, "Expected specific image URL");
            Assert.AreEqual("3x3x3 inches", product.Dimensions, "Expected specific dimensions");
        }

        [Test]
        public void TestSearchForNonStandardDimensions()
        {
            var products = SearchBar.SearchProducts("N/A");
            Assert.IsTrue(products.Count > 0, "Expected results for non-standard dimensions 'N/A'");
        }

        [Test]
        public void TestSearchWithPartialWordAndSpecialCharacters()
        {
            var products = SearchBar.SearchProducts("Tomato%");
            Assert.IsTrue(products.Count > 0, "Expected results for 'Tomato%'");
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



// using NUnit.Framework;
// using MvcMovie.Models;
// using System.Collections.Generic;

// namespace MvcMovie.Tests
// {
//     [TestFixture]
//     public class TestSearchBar
//     {
//         private SqlConnection? _connection;

//         [SetUp]
//         public void Setup()
//         {
//             // Connect to the test database before each test.
//             _connection = Database.ConnectToDatabase();
//         }

//         [Test]
//         public void TestSearchProductsReturnsResults()
//         {
//             // Test the search functionality with a known value that should return results
//             var products = SearchBar.SearchProducts("Organic Apple");
//             Assert.IsTrue(products.Count > 0, "No products found matching 'Organic Apple'");
//         }

//         [Test]
//         public void TestSearchProductsWithNoResults()
//         {
//             // Test the search functionality with a value known to produce no results
//             var products = SearchBar.SearchProducts("NonExistentProduct");
//             Assert.AreEqual(0, products.Count, "Products should not be found for 'NonExistentProduct'");
//         }

//         [TearDown]
//         public void TearDown()
//         {
//             // Close the database connection after each test.
//             if (_connection != null)
//             {
//                 Database.CloseConnection(_connection);
//             }
//         }
//     }
// }
