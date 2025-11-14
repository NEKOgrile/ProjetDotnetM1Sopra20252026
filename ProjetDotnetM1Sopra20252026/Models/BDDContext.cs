using Microsoft.EntityFrameworkCore;

namespace ProjetDotnetM1Sopra20252026.Models
{
    public class BDDContext : DbContext
    {
        public BDDContext(DbContextOptions<BDDContext> options):
            base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
    }
}
