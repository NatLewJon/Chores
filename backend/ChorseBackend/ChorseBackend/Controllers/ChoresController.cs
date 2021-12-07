using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChorseBackend.Data;
using ChorseBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChorseBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChoresController : ControllerBase
    {
        private readonly ChorseBackendContext _context;

        public ChoresController(ChorseBackendContext context)
        {
            _context = context;
        }

        // GET: api/Chores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chores>>> GetChores()
        {
            return await _context.Chores.ToListAsync();
        }

        // GET: api/Chores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chores>> GetChores(int id)
        {
            var chores = await _context.Chores.FindAsync(id);

            if (chores == null)
            {
                return NotFound();
            }

            return chores;
        }

        [HttpGet]
        [Route("ByUser/{clientId}")]
        public async Task<ActionResult<IEnumerable<Chores>>> GetChoresByUser(int clientId)
        {
            var chores = await _context.Chores.Where(x => x.assignee.id == clientId).ToListAsync();
            if (chores == null)
            {
                return NotFound();
            }

            return chores;
        }

        // PUT: api/Chores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChores(int id, Chores chores)
        {
            if (id != chores.id)
            {
                return BadRequest();
            }

            _context.Entry(chores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoresExists(id))
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

        // POST: api/Chores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chores>> PostChores(Chores chores)
        {
            if(chores.assignee == null)
            {
                return BadRequest();
            }
            else
            {
                Client client = _context.Client.FirstOrDefault(x => x.id == chores.assignee.id);

                if(client == null)
                {
                    return NotFound("Client was not found");
                }
                chores.assignee = client;
            }
           
            _context.Chores.Add(chores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChores", new { id = chores.id }, chores);
        }

        // DELETE: api/Chores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChores(int id)
        {
            var chores = await _context.Chores.FindAsync(id);
            if (chores == null)
            {
                return NotFound();
            }

            _context.Chores.Remove(chores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoresExists(int id)
        {
            return _context.Chores.Any(e => e.id == id);
        }
    }
}
