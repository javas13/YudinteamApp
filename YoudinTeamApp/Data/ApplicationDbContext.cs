using Microsoft.EntityFrameworkCore;
using YoudinTeamApp.Models;
namespace YoudinTeamApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
