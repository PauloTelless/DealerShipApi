using DealerShipApi.Context;
using DealerShipApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DealerShipApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DealerShipAppContext _context;

    public UsersController(DealerShipAppContext context)
    {
        _context = context;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Usuario>> Users()
    {
        var users = _context.Usuarios.Include(x => x.CarrosFavoritados).ToList();

        return Ok(users);
    }

    [HttpGet("{userId}")]
    public ActionResult<Usuario> GetUser(string userId)
    {
        var user = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == userId);

        return user;
    }

    [HttpPut("{userId}/{carroId}")]
    public ActionResult<Usuario> PutUser(string userId, Guid carroId)
    {
        Usuario userFiltrado = new Usuario();
        Carro  carroFiltrado = new Carro();

        if (userId is not null)
        {
            userFiltrado = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == userId);

        }
        

        if (carroId.ToString() is not null)
        {
            carroFiltrado = _context.Carros.FirstOrDefault(x => x.CarroId == carroId);

            userFiltrado.CarrosFavoritados.Add(carroFiltrado);
        }


        _context.SaveChanges(); 

        return Ok(userFiltrado); 
    }

    [HttpPut("{userId}")]
    public ActionResult<Usuario> PutUserConfiguration(string userId, Usuario usuario)
    {
        if (usuario.UsuarioId != userId)
        {
            return NotFound();
        }
        
        _context.Usuarios.Entry(usuario).State = EntityState.Modified;

        _context.SaveChanges();

        return usuario;
    }

}
