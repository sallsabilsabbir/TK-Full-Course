using ASP.NETCORE6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCORE6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category>Categories { get; set; }
    }
}
