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

    }
