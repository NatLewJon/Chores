﻿using System;
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
    public class KanbansController : ControllerBase
    {
        private readonly ChorseBackendContext _context;

        public KanbansController(ChorseBackendContext context)
        {
            _context = context;
        }

        // GET: api/Kanbans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kanban>>> GetKanban()
        {
            return await _context.Kanban.ToListAsync();
        }

        // GET: api/Kanbans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kanban>> GetKanban(int id)
        {
            var kanban = await _context.Kanban.FindAsync(id);

            if (kanban == null)
            {
                return NotFound();
            }

            return kanban;
        }

        // PUT: api/Kanbans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKanban(int id, Kanban kanban)
        {
            if (id != kanban.Id)
            {
                return BadRequest();
            }

            _context.Entry(kanban).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanExists(id))
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

        // POST: api/Kanbans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kanban>> PostKanban(Kanban kanban)
        {
            _context.Kanban.Add(kanban);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKanban", new { id = kanban.Id }, kanban);
        }

        // DELETE: api/Kanbans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKanban(int id)
        {
            var kanban = await _context.Kanban.FindAsync(id);
            if (kanban == null)
            {
                return NotFound();
            }

            _context.Kanban.Remove(kanban);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KanbanExists(int id)
        {
            return _context.Kanban.Any(e => e.Id == id);
        }
    }
}
