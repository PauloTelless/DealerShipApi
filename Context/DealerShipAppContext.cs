using DealerShipApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Context;

public class DealerShipAppContext : IdentityDbContext<AplicationUser>
{
    public DealerShipAppContext(DbContextOptions<DealerShipAppContext> options): base (options) { }

    public DbSet<Carro> Carros { get; set; }
    public DbSet<CategoriaCarro> Categorias { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
