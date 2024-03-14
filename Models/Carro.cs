using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerShipApi.Models;

public class Carro
{
    [Key]
    public Guid CarroId { get; set; }
    public string? ModeloCarro { get; set; }
    public string? MarcaCarro { get; set; }
    public string? DescricaoCarro { get; set; }
    public string? ImagemCarro { get; set; }
    public decimal PrecoCarro { get; set; }
    public string? PlacaCarro { get; set; }
    public int AnoCarro { get; set; }
    public int QuantidadeDisponivel { get; set; }   
    public DateTime AnoLancamento { get; set; }

  
    public Guid CategoriaId { get; set; }   
    public CategoriaCarro? Categoria { get; set; }

}
