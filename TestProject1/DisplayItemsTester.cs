

using Microsoft.AspNetCore.Authentication;
using MvcMovie.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace TestProject1
{
    public class DisplayItemsTester
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestItemDisplay()
        {
            Assert.That(DisplayItems.getAllItems()[0].Name, Is.EqualTo("Potato"));
        }
        [Test]
        public void TestItemDisplay2()
        {
            Assert.That(DisplayItems.getAllItems()[0].Price, Is.EqualTo(0.5));
        }
        [Test]
        public void TestItemDisplay3()
        {
            Assert.That(DisplayItems.getAllItems()[3].Price, Is.EqualTo(0.75));
        }
    }
}