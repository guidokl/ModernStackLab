using ModernStackLab.Models;
using Microsoft.EntityFrameworkCore;

namespace ModernStackLab.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}