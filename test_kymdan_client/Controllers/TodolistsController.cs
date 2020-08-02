using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_kymdan_client.Models;

namespace test_kymdan_client.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "application")]
    //[Authorize(Policy = "ApplicationPolicy")]
    [ApiController]
    public class TodolistsController : ControllerBase
    {
        private readonly todo3Context _context;

        public TodolistsController(todo3Context context)
        {
            _context = context;
        }

        // GET: api/Todolists
        [HttpGet]
       // [Authorize(Policy = "AdminPolicy","ewe")]
      //  [Authorize(Policy = "AdminPolicy","1")]
        [Authorize(Policy = "ApplicationPolicy")]
        public async Task<ActionResult<IEnumerable<Todolist>>> GetTodolist()
        {
            return await _context.Todolist.ToListAsync();
        }

        // GET: api/Todolists/5
        [HttpGet("{id}")]
        //[Authorize(Policy = "AdminPolicy")]
      //  [Authorize(Policy = "ApplicationPolicy")]
        public async Task<ActionResult<Todolist>> GetTodolist(int id)
        {
            var todolist = await _context.Todolist.FindAsync(id);

            if (todolist == null)
            {
                return NotFound();
            }

            return todolist;
        }

        // PUT: api/Todolists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodolist(int id, Todolist todolist)
        {
            if (id != todolist.Id)
            {
                return BadRequest();
            }

            _context.Entry(todolist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodolistExists(id))
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

        // POST: api/Todolists
        [HttpPost]
        public async Task<ActionResult<Todolist>> PostTodolist(Todolist todolist)
        {
            _context.Todolist.Add(todolist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodolist", new { id = todolist.Id }, todolist);
        }

        // DELETE: api/Todolists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todolist>> DeleteTodolist(int id)
        {
            var todolist = await _context.Todolist.FindAsync(id);
            if (todolist == null)
            {
                return NotFound();
            }

            _context.Todolist.Remove(todolist);
            await _context.SaveChangesAsync();

            return todolist;
        }

        private bool TodolistExists(int id)
        {
            return _context.Todolist.Any(e => e.Id == id);
        }
    }
}
