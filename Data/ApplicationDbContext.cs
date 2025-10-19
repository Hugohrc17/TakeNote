using Microsoft.EntityFrameworkCore;
using TakeNote.Models;

namespace TakeNote.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Nota> Notas { get; set; }
    }
}
