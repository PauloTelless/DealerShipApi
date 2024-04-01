using DealerShipApi.DTOs;
using System.Collections.ObjectModel;

namespace DealerShipApi.Models;

public class Usuario                    
{               
    public Usuario()            
    {
        CarrosFavoritados = new Collection<Carro>();
    }

    public string? UsuarioId { get; set; }  
    public string? UsuarioNomeCompleto { get; set; }
    public string? UsuarioNome { get; set; }
    public string? UsuarioCpf { get; set; }
    public string? UsuarioRg { get; set; }          
    public string? UsuarioEmail { get; set; }   
    public string? UsuarioContato { get; set; }
    public string? UsuarioEndereco { get; set; }        

    public Collection<Carro>? CarrosFavoritados { get; set; }

}
