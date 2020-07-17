using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_kymdan.Models;

namespace test_kymdan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly todoContext _context;

        public CategorysController(todoContext context)
        {
            _context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorys>>> GetCategorys()
        {
            return await _context.Categorys.ToListAsync();
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorys>> GetCategorys(int id)
        {
            var categorys = await _context.Categorys.FindAsync(id);

            if (categorys == null)
            {
                return NotFound();
            }

            return categorys;
        }

        // PUT: api/Categorys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorys(int id,Categorys categorys)
        {
            if (id != categorys.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorysExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categorys
        [HttpPost]
        public async Task<ActionResult<Categorys>> PostCategorys(Categorys categorys)
        {
            _context.Categorys.Add(categorys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorys", new { id = categorys.Id }, categorys);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categorys>> DeleteCategorys(int id)
        {
            var categorys = await _context.Categorys.FindAsync(id);
            if (categorys == null)
            {
                return NotFound();
            }

            _context.Categorys.Remove(categorys);
            await _context.SaveChangesAsync();

            return categorys;
        }

        private bool CategorysExists(int id)
        {
            return _context.Categorys.Any(e => e.Id == id);
        }
    }
}
