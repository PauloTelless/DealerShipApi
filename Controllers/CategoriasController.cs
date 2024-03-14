using DealerShipApi.Context;
using DealerShipApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly DealerShipAppContext _context;

    public CategoriasController(DealerShipAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaCarro>>> GetCategoriasAsync()
    {
        try
        {
            var categoriasCarro = await _context
            .Categorias
            .AsNoTracking()
            .ToListAsync();

            return Ok(categoriasCarro);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<ActionResult<CategoriaCarro>> PostCategoriaAsync(CategoriaCarro categoria)
    {
        try
        {
            _context.Categorias.Add(categoria);

            await _context.SaveChangesAsync();

            return Ok(categoria);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{categoriaId}")]
    public async Task<ActionResult<CategoriaCarro>> PutCategoriaAsync(CategoriaCarro categoria, Guid categoriaId)
    {
        try
        {
            if (categoria.CategoriaId.ToString() != categoriaId.ToString())
            {
                return NotFound();
            }

            _context.Categorias.Entry(categoria).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(categoria);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            
        }
        
    }

    [HttpDelete("{categoriaId}")]    
    public async Task<ActionResult<CategoriaCarro>> DeleteCategoriaCarroAsync(Guid categoriaId)
    {
        try
        {
            var categoriaCarro = await _context.Categorias
            .Include(carros => carros.Carros)
            .FirstOrDefaultAsync(categoria => categoria.CategoriaId == categoriaId);

            if (categoriaCarro != null)
            {
                _context.Remove(categoriaCarro);

                await _context.SaveChangesAsync();

            }

                return Ok(categoriaCarro);
            
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
        
    }
}
