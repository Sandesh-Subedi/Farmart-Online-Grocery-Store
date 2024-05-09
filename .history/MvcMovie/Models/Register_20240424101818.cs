using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace MvcMovie.Models
 {
    public class Register
    {
        public string Usermame { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public DateTime DateOfBirth { get; set; }
        
    }
}
