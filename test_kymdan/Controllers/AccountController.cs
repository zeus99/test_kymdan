using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_kymdan.Data.Models;
using test_kymdan.Models;

namespace test_kymdan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<User> UserManager { get; }
        public AccountController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser model)
        {
            //TODO: Validate request model

            var user = new User() { Email = model.Email, UserName = model.Email };
            user.Claims.Add(new IdentityUserClaim<string>()
            {
                ClaimType = JwtClaimTypes.GivenName,
                ClaimValue = model.Firstname
            });
            user.Claims.Add(new IdentityUserClaim<string>()
            {
                ClaimType = JwtClaimTypes.FamilyName,
                ClaimValue = model.Lastname
            });
            user.Claims.Add(new IdentityUserClaim<string>()
            {
                ClaimType = JwtClaimTypes.Gender,
                ClaimValue = model.Gender.ToString()
            });
            user.Claims.Add(new IdentityUserClaim<string>()
            {
                ClaimType = JwtClaimTypes.BirthDate,
                ClaimValue = model.BirthDate.ToString("yyyy-MM-dd")
            });
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                //TODO: Handle failed request like: Duplicate Username, Email,...
                return BadRequest();
            }
        }
    }
}