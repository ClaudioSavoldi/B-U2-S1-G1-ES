using Microsoft.EntityFrameworkCore;

namespace B_U2_S1_G1_ES.Models.Entity
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } 
    
    }
}

  