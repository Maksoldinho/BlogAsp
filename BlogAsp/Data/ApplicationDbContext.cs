using BlogAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAsp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<News_> News { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
