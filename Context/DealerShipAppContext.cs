using DealerShipApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Context;

public class DealerShipAppContext : DbContext
{
    public DealerShipAppContext(DbContextOptions<DealerShipAppContext> options): base (options) { }

    public DbSet<Carro> Carros { get; set; }
    public DbSet<CategoriaCarro> Categorias { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Marca> Marcas { get; set; }    

}
