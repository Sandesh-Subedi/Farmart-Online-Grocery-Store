using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Runtime.Intrinsics.X86;
using NUnit.Framework;
using MvcMovie.Models;

namespace TestProject1
{
    internal class CartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddItem1()
        {
            var onions = new Product(1, "onions", "layers and onions", "vegetables", 10.0, "10/2/24", "10/31/24", 5.21);
            var cart = new Cart(1);
            cart.AddItem(onions, 3);
            Assert.Multiple(() =>
            {
                Assert.That(cart.Products, Does.Contain(onions));
                Assert.That(cart.Quantity, Is.EqualTo(3));
            });
        }

        [Test]
        public void TestAddItem2()
        {
            var squash = new Product(2, "squash", "squish", "vegetables", 10.0, "10/2/24", "10/31/24", 5.21);
            var potatoes = new Product(3, "potatoes", "brown ground apple", "vegetable", 5.0, "11/12/24", "12/5/24", 7.32);
            var apples = new Product(4, "apples", "red, round and sweet", "fruit", 2.3, "5/17/24", "6/17/24", 4.72);
            var cart = new Cart(1);
            cart.AddItem(squash, 2);
            cart.AddItem(potatoes, 1);
            cart.AddItem(apples, 4);
            Assert.Multiple(() =>
            {
                Assert.That(cart.Products, Does.Contain(apples));
                Assert.That(cart.Products, Does.Contain(squash));
                Assert.That(cart.Products, Does.Contain(potatoes));
                Assert.That(cart.Quantity, Is.EqualTo(7));
            });
        }

        [Test]
        public void TestAddItem3()
        {
            var onions = new Product(5, "onions", "layers and onions", "vegetables", 10.0, "10/2/24", "10/31/24", 5.21);
            var grapes = new Product(6, "grapes", "purple eyeballs", "fruit", 5.0, "11/12/24", "12/5/24", 7.32);
            var zucchini = new Product(7, "zucchini", "green and long", "vegetable", 2.3, "5/17/24", "6/17/24", 4.72);
            var bananas = new Product(8, "bananas", "yellow, long and slender", "fruit", 1.2, "7/2/24", "11/4/24",
                8.82);
            var cart = new Cart(1);
            cart.AddItem(onions,2);
            cart.AddItem(grapes, 1);
            cart.AddItem(zucchini, 1);
            cart.AddItem(bananas, 5);
            int productsListSize = cart.Products.Count;
            Assert.Multiple(() =>
            {
                Assert.That(cart.Products, Is.Not.Empty);
                Assert.That(cart.Products, Does.Contain(grapes));
                Assert.That(cart.Products, Does.Contain(onions));
                Assert.That(cart.Products, Does.Contain(zucchini));
                Assert.That(cart.Products, Does.Contain(bananas));
                Assert.That(cart.Quantity, Is.EqualTo(9));
                Assert.That(productsListSize, Is.EqualTo(9));
            });
        }

        [Test]
        public void TestClearCart()
        {
            var onions = new Product(1, "onions", "layers and onions", "vegetables", 10.0, "10/2/24", "10/31/24", 5.21);
            var grapes = new Product(2, "grapes", "purple eyeballs", "fruit", 5.0, "11/12/24", "12/5/24", 7.32);
            var zucchini = new Product(3, "zucchini", "green and long", "vegetable", 2.3, "5/17/24", "6/17/24", 4.72);
            var bananas = new Product(4, "bananas", "yellow, long and slender", "fruit", 1.2, "7/2/24", "11/4/24",
                8.82);
            var cart = new Cart(1);
            cart.AddItem(onions, 1);
            cart.AddItem(grapes, 1);
            cart.AddItem(zucchini, 1);
            cart.AddItem(bananas, 1);
            cart.ClearCart();
            Assert.Multiple(() =>
            {
                Assert.That(cart.Quantity, Is.EqualTo(0));
                Assert.That(cart.Products, Is.Empty);
            });
        }

        [Test]
        public void TestRemoveItem1()
        {
            var dragonFruit = new Product(1, "dragon fruit", "spiky and pink", "fruit", 3.7, "3/12/25", "6/18/24", 9.77);
            var cart = new Cart(2);
            cart.AddItem(dragonFruit, 3);
            cart.RemoveItem(dragonFruit,1);
            Assert.Multiple(() =>
            {
                Assert.That(cart.Quantity, Is.EqualTo(2));
                Assert.That(cart.Products, Does.Contain(dragonFruit));
            });
        }

        [Test]
        public void TestRemoveItem2()
        {
            var orange = new Product(1, "orange", "round and orange", "fruit", 2.1, "5/10/24", "8/18/24", 7.22);
            var mandarin = new Product(2, "mandarin", "almost an orange", "fruit", 2.41, "5/10/24", "8/18/24", 6.22);
            var cart = new Cart(1);
            cart.AddItem(orange, 3);
            cart.AddItem(mandarin, 4);
            cart.RemoveItem(orange,2);
            int productsListSize = cart.Products.Count;
            Assert.Multiple(() =>
            {
                Assert.That(cart.Quantity, Is.EqualTo(5));
                Assert.That(cart.Products, Does.Contain(orange));
                Assert.That(cart.Products, Does.Contain(mandarin));
                Assert.That(productsListSize, Is.EqualTo(5));
            });
        }
        [Test]
        public void TestRemoveItem3()
        {
            var cucumber = new Product(1, "cucumber", "green and long", "vegetable", 3.7, "3/12/25", "6/18/24", 9.77);
            var cart = new Cart(4);
            cart.AddItem(cucumber, 1);
            cart.RemoveItem(cucumber, 1);
            Assert.Multiple(() =>
            {
                Assert.That(cart.Products, Is.Empty);
                Assert.That(cart.Quantity, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestGetProductById1()
        {
            var pineapple = new Product(1, "pineapple", "tall and spiky", "fruit", 4.8, "8/1/24", "9/10/24", 10.01);
            var cart = new Cart(1);
            cart.AddItem(pineapple, 1);
            var item = cart.GetProductById(1);
            Assert.That(item, Is.EqualTo(pineapple));
        }

        [Test]
        public void TestGetProductById2()
        {
            var tomato = new Product(1,"tomato", "maybe a fruit, maybe a vegetable", "vegetable", 0.8, "5/1/24", "6/13/24", 4.50);
            var watermelon = new Product(2, "watermelon", "green, big and round", "fruit", 11.2, "7/5/24", "8/31/24",
                6.27);
            var cart = new Cart(1);
            cart.AddItem(tomato, 3);
            cart.AddItem(watermelon, 1);
            var item = cart.GetProductById(2);
            Assert.That(item, Is.EqualTo(watermelon));
        }

        [Test]
        public void TestGetProductById3()
        {
            var durian = new Product(1, "durian", "stinky ball", "fruit", 1.3, "12/26/24", "1/1/25", 21.10);
            var jackfruit = new Product(2, "jackfruit", "big, yellow, spiky, bold smell", "fruit", 10.2,"2/2/24", "8/17/24",
                15.10);
            var egg = new Product(3, "egg", "not a fruit or vegetable","fruit", 1.2, "12/2/24", "12/31/24", 12.1);
            var cart = new Cart(1);
            cart.AddItem(durian, 4);
            cart.AddItem(jackfruit, 7);
            cart.AddItem(egg, 1);
            var item = cart.GetProductById(3);
            Assert.That(item, Is.EqualTo(egg));
        }
    }
}
