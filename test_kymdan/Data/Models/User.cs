using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace test_kymdan.Models
{
        public class User : IdentityUser
        {
            public ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
        }
    
}
