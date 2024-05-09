

using Microsoft.AspNetCore.Authentication;
using MvcMovie.Models;
using System.Runtime.Intrinsics.X86;

namespace TestProject1
{
    public class SignInTester
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogin1()
        {    
            Assert.That(SignIn.LoginWithData("johnfarmer", "password123"), Is.EqualTo(true));
        }

        [Test]
        public void TestLogin2()
        {
            Assert.That(SignIn.LoginWithData("janecustomer", "securepassword"), Is.EqualTo(true));
        }
        [Test]
        public void TestLogin3WrongPassword()
        {
            Assert.That(SignIn.LoginWithData("janecustomer", "pass003"), Is.EqualTo(false));
        }
        [Test]
        public void TestLogin4WrongPassword()
        {
            Assert.That(SignIn.LoginWithData("bobcustomer", "grapejuice"), Is.EqualTo(false));
        }
        [Test]
        public void TestLogin4WrongUsername()
        {
            Assert.That(SignIn.LoginWithData("Apple", "grapejuice"), Is.EqualTo(false));
        }
        [Test]
        public void TestLogin5WrongUsername()
        {
            Assert.That(SignIn.LoginWithData("Apple", "securepassword"), Is.EqualTo(false));
        }
        [Test] 
        public void TestTester() 
        {
            Assert.AreEqual(7, 7);
        }
    }
}