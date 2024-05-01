using Microsoft.EntityFrameworkCore;
using NotesBackend.Models;

namespace NotesBackend.Data 
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}