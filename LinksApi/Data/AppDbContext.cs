using LinksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Link> Links { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
