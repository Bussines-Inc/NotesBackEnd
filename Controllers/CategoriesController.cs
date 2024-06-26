using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesBackend.Data;
using NotesBackend.Models;

namespace  CategoriesController.Controllers;

    [Route("api/[Controller]")]
    //[Route("api/editnotes")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NotesContext _context;
        public CategoriesController(NotesContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            return await _context.Categories.ToListAsync(); 
        }

        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategory(Categories c)
        {
            _context.Categories.Add(c);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCategories", new {id = c.Id}, c);
        }
    }