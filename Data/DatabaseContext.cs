using Microsoft.EntityFrameworkCore;

namespace crudBook.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options ) : base(options)
        {

        }
    }
}
