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
    public string? UsuarioNome { get; set; }
    public Collection<Carro>? CarrosFavoritados { get; set; }

}
