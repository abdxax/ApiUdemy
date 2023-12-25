using APICourseUdemy.Models;
using Microsoft.EntityFrameworkCore;

namespace APICourseUdemy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<AppUser> appUsers { get; set; }
    }
}
