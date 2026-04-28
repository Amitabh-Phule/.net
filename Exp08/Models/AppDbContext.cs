using Microsoft.EntityFrameworkCore;

namespace Exp08.Models
{
    // Application database context extending DbContext
    public class AppDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes them to the base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Represents the Students table in the database
        public DbSet<Student> Students { get; set; }
    }
}
