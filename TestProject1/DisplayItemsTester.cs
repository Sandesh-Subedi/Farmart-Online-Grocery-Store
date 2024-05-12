

using Microsoft.AspNetCore.Authentication;
using Farmart.Models;
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
            Assert.That(DisplayItems.getAllItems()[0].Name, Is.EqualTo("Heirloom Tomatoes"));
            
        }
    }
}