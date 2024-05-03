

using Microsoft.AspNetCore.Authentication;
using MvcMovie.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace TestProject1
{
    public class UserTester
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestRegister1Username()
        {
            User user = new User("johnfarmer", "1", "i@gmail.com", "John", "loser");
            Assert.That(user.RegisterUser(), Is.EqualTo(false));
            
        }
        [Test]
        public void TestRegister2Username()
        {
            User user = new User("alicefarmer", "1", "d@gmail.com", "Alice", "Brown");
            Assert.That(user.RegisterUser(), Is.EqualTo(false));
        }

        [Test]
        public void TestRegister3Gmail()
        {
            User user = new User("notrealusername", "1", "alice.brown@example.com", "Alice", "Brown");
            Assert.That(user.RegisterUser(), Is.EqualTo(false));
        }

        [Test]
        public void TestRegister4Unique()
        {
            User user = new User("janecustomer", "random4", "jane.smith@example.com", "Jane", "Smith");
            Assert.That(user.RegisterUser(), Is.EqualTo(false));
        }

        [Test]
        public void TestRegister5Unique()
        {
            User user = new User("bobcustomer", "random5", "bob.johnson@example.com", "Bob", "Johnson");
            Assert.That(user.RegisterUser(), Is.EqualTo(false));
        }


        [Test] 
        public void TestTester() 
        {
            Assert.That(7, Is.EqualTo(7));
        }
    }
}