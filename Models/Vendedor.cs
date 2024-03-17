using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DealerShipApi.Models;

public class Vendedor
{

    [Key]
    public Guid VendedorId { get; set; }
    public string? NomeVendedor { get; set; }
    public string? CpfVendedor { get; set; }
    public string? EnderecoVendedor { get; set; }
    public string? SalarioVendedor { get; set; }    
    public string? EmailVendedor { get; set; }
    public string? ContatoVendedor { get; set; }
    public string? FotoVendedor { get; set; }  
    public string? EstadoVendedor { get; set; }
    public string? CidadeVendedor { get; set; }     
    public DateTime DataNascimentoVendedor { get; set; }
    public DateTime DataAdmissao { get; set; }

}
