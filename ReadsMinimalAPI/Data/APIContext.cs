using Microsoft.EntityFrameworkCore;

namespace ReadsMinimalAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<Models.Book> Books { get; set; }
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }
    }
}
