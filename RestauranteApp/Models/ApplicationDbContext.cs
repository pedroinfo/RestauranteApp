using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestauranteApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        
    }
}