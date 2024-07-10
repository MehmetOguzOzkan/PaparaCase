using Microsoft.EntityFrameworkCore;
using WebApiCase1.Models;

namespace WebApiCase1.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbContext configuration and dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        // Database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
