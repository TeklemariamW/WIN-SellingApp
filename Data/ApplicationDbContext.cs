using Microsoft.EntityFrameworkCore;
using WIN_sellingApp.Models;

namespace WIN_sellingApp.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {}

        public DbSet<Customer>? customers { get; set; }
    }
}