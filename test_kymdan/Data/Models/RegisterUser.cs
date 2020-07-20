using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_kymdan.Data.Models
{
    public class RegisterUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
