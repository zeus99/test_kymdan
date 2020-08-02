using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_kymdan_client.Controllers
{
    [Route("api/[controller]")]
    public class testController: Controller
    {
        [HttpGet]
      //  [Authorize(Policy = "Api1Policy")]
        [Authorize]
        public IActionResult Get()
        {
            return this.Ok("Hello w");
        }

    }
}
