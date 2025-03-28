using crudBook.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace crudBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } 
    
    }
}
