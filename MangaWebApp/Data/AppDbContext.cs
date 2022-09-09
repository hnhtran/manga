using MangaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaWebApp.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> CategoryTable { get; set; }
    }
}
