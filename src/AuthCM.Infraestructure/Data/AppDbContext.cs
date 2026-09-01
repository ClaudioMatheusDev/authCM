using Microsoft.EntityFrameworkCore;
using AuthCM.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthCM.Infraestructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
