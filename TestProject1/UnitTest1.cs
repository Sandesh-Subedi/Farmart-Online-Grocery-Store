

using Microsoft.AspNetCore.Authentication;
using MvcMovie.Models;
using System.Runtime.Intrinsics.X86;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogin1()
        {    
            Assert.That(SignIn.LoginWithData("user1", "pass001"), Is.EqualTo(true));
        }

        [Test]
        public void TestLogin2()
        {
            Assert.That(SignIn.LoginWithData("user2", "pass002"), Is.EqualTo(true));
        }

        public void TestLogin3WrongPassword()
        {
            Assert.That(SignIn.LoginWithData("user2", "pass003"), Is.EqualTo(false));
        }
        public void TestLogin4WrongPassword()
        {
            Assert.That(SignIn.LoginWithData("user2", "grapejuice"), Is.EqualTo(false));
        }

        public void TestLogin4WrongUsername()
        {
            Assert.That(SignIn.LoginWithData("Apple", "grapejuice"), Is.EqualTo(false));
        }
        public void TestLogin5WrongUsername()
        {
            Assert.That(SignIn.LoginWithData("Apple", "pass001"), Is.EqualTo(false));
        }
        [Test] 
        public void TestTester() 
        {
            Assert.AreEqual(7, 7);
        }
    }
}