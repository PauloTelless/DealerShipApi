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
    public async Task<ActionResult<IEnumerable<Usuario>>> UsersAsync()
    {
        try
        {
            var users = await _context.Usuarios
                .Include(x => x.CarrosFavoritados)
                .ToListAsync();

            return Ok(users);

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<Usuario>> GetUserAsync(string userId)
    {
        try
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.UsuarioId == userId);

            return user;

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{userId}/{carroId}")]
    public async Task<ActionResult<Usuario>> PutUserAsync(string userId, Guid carroId)      
    {
        Usuario userFiltrado = new Usuario();
        Carro  carroFiltrado = new Carro();

        try
        {
            userFiltrado = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == userId);

        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);  
        }

        try
        {
            carroFiltrado = await _context.Carros
                .FirstOrDefaultAsync(x => x.CarroId == carroId);

            userFiltrado.CarrosFavoritados
                .Add(carroFiltrado);

            await _context.SaveChangesAsync(); 
            
            return Ok(userFiltrado); 
        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);

        }


    }

    [HttpPut("Favorite/Car/Delete/{userId}/{carroId}")]
    public async Task<ActionResult<Usuario>> DeleteCarFavoriteAsync(string userId, Guid carroId)  
    {
        Usuario usuarioFiltrado = new Usuario();
        Carro carroFiltrado = new Carro();

        try
        {
            usuarioFiltrado = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.UsuarioId == userId);

        } 
        catch (Exception ex)
        {

            return NotFound(ex.Message);  
        }


        try
        {
            carroFiltrado = _context
                .Carros
                .FirstOrDefault(y => y.CarroId == carroId);

            usuarioFiltrado.CarrosFavoritados
                .Remove(carroFiltrado);

            _context.Usuarios
                .Entry(usuarioFiltrado)
                .State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return usuarioFiltrado;

        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);
        }


    }

    [HttpPut("{userId}")]
    public async Task<ActionResult<Usuario>> PutUserConfigurationAsync(string userId, Usuario usuario)
    {
        try
        {

            if (usuario.UsuarioId != userId)
            {
                return NotFound();
            }

            _context.Usuarios
                .Entry(usuario)
                .State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
            return usuario;     
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

}
