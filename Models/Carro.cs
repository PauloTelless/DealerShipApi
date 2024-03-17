using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealerShipApi.Models;

public class Carro
{
    [Key]
    public Guid CarroId { get; set; }
    public string? ModeloCarro { get; set; }
    public string? MarcaCarro { get; set; }
    public string? CorCarro { get; set; }       
    public string? MotorCarro { get; set; }
    public string? ConsumoCarro { get; set; }
    public string? EstadoCarro { get; set; }        
    public string? ImagemCarro { get; set; }
    public string? PrecoCarro { get; set; }
    public string? PlacaCarro { get; set; }
    public string? AnoCarro { get; set; }
    public string? QuilometragemCarro { get; set; }
    public int QuantidadeDisponivel { get; set; }      
    public string AnoLancamento { get; set; } = DateTime.UtcNow.ToString("dd/mm/yyyy");


    [Required]
    public Guid CategoriaId { get; set; }

    public Guid VendedorId { get; set; }    


    public CategoriaCarro? Categoria { get; set; }
    public Vendedor? Vendedor { get; set; }

}
