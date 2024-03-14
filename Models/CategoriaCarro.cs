using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DealerShipApi.Models;

public class CategoriaCarro
{
    public CategoriaCarro()
    {
        Carros = new Collection<Carro>();
    }

    [Key]
    public Guid CategoriaId { get; set; }
    public string? NomeCategoria { get; set; }

    public Collection<Carro> Carros { get; set; }  
}
