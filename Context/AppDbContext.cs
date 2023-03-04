using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }
        DbSet<MyLog> MyLogs { get; set; }
    }
}
