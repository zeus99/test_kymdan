using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_kymdan_client.Models;


namespace test_kymdan_client.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminPolicy")]
    // [ApiController]

    public class CategorysController : ControllerBase
    {
        private readonly todo3Context _context;
        

        public CategorysController(todo3Context context)
        {
            _context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorys>>> GetCategorys()
        {
            return await _context.Categorys.ToListAsync();
        }

        // GET: api/Categorys/5.
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
        public async Task<IActionResult> PutCategorys(int id, Categorys categorys)
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
        public async Task<ActionResult<string>> DeleteCategorys(int id)
        {
            var categorys = await _context.Categorys.FindAsync(id);
            if (categorys == null)
            {
                return NotFound();
            }

            if (CategorysTodoListExists(id))
            {

                return "Category exists in todo list,cannot delete !";

            }
            else //not exists todolist
            {
                _context.Categorys.Remove(categorys);
                await _context.SaveChangesAsync();
                return categorys.Name + "has been deleted";
            }

        
        }


        private bool CategorysExists(int id)
        {
            return _context.Categorys.Any(e => e.Id == id);
        }

        private bool CategorysTodoListExists(int id)
        {
            return _context.Todolist.Any(e => e.CategoryId == id);
        }

    }
}
