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
    public async Task<CategoriaCarro> PutCategoriaAsync(CategoriaCarro categoria, Guid categoriaId)
    {
        try
        {
            var categoriaFiltrada = await _context
            .Categorias
            .FirstOrDefaultAsync(categoriaIdFiltrada => categoriaIdFiltrada.CategoriaId == categoria.CategoriaId);

            _context.Categorias.Entry(categoriaFiltrada).State = EntityState.Modified;  

            await _context.SaveChangesAsync();

            return categoriaFiltrada;
        }
        catch (Exception)
        {

            throw;
        }
        
    }

    [HttpDelete("{categoriaId}")]
    public async Task<CategoriaCarro> DeleteCategoriaAsync(Guid categoriaId)
    {
        try
        {
            var categoriaFiltrada = await
            _context.Categorias
            .FirstOrDefaultAsync(categoriaIdFiltrada => categoriaIdFiltrada.CategoriaId == categoriaId);

            _context.Categorias.Remove(categoriaFiltrada);

            await _context.SaveChangesAsync();

            return categoriaFiltrada;
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
