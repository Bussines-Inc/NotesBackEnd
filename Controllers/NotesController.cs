using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesBackend.Data;
using NotesBackend.Models;

namespace  NotesBackend.Controllers;

    [Route("api/[Controller]")]
    //[Route("api/editnotes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesContext _context;
        public NotesController(NotesContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notes>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetNote(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }
            return notes;
        }
        //ELiminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notes>> DeleteNote(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //crear
        [HttpPost]
        public async Task<ActionResult<Notes>> PostNote(Notes n)
        {
            _context.Notes.Add(n);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetNotes", new {id = n.Id}, n);
        }

        //editar
        [HttpPatch("{id}")]
        public async Task<ActionResult<Notes>> EditNote(int id, Notes n)
        {
            if (id != n.Id)
            {
                return BadRequest();
            }
            _context.Entry(n).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!NotesExists(id))
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

        private bool NotesExists(int id)
        {
        return _context.Notes.Any(e => e.Id == id);
        }
}
