using Microsoft.EntityFrameworkCore;
using ReadsAPI.Models;

namespace ReadsAPI.Data
{
    public class ApiContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApiContext(DbContextOptions<ApiContext>options)
            : base(options)
        {

        }
    }
}
