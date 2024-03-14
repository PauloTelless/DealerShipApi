using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DealerShipApi.Models;

public class Vendedor
{
    public Vendedor()
    {
        Carros = new Collection<Carro>();
    }

    [Key]
    public Guid VendedorId { get; set; }
    public string? NomeVendedor { get; set; }
    public string? CpfVendedor { get; set; }
    public string? EnderecoVendedor { get; set; }
    public string? FotoVendedor { get; set; }  
    public DateTime DataNascimentoVendedor { get; set; }    
    public decimal SalarioVendedor { get; set; }

    public Collection<Carro> Carros { get; set; }
}
