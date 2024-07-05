using Microsoft.EntityFrameworkCore;
using WebApiCase1.Models;

namespace WebApiCase1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
