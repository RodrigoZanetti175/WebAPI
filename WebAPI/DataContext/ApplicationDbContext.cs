using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
