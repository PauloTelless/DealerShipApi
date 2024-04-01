using DealerShipApi.Context;
using DealerShipApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Controllers;

[Route("[controller]")]
[ApiController]
public class MarcasController : ControllerBase
{
    private readonly DealerShipAppContext _context;

    public MarcasController(DealerShipAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marca>>> GetMarcasAsync()
    {
        try
        { 
            var marcas = await _context
                .Marcas
                .AsNoTracking()
                .ToListAsync();
            
            return Ok(marcas);  

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<ActionResult<Marca>> PostMarcaAsync(Marca marca)
    {
        try
        {
            _context.Marcas.Add(marca);

            await _context.SaveChangesAsync();

            return Ok(marca);

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{marcaId}")]
    public async Task<ActionResult<Marca>> PutMarcaAsync(Guid marcaId, Marca marca)
    {
        try
        {
            var existingMarca = await _context
                .Marcas
                .FindAsync(marcaId);

            if (existingMarca == null)
            {
                return NotFound();
            }

            if (marcaId != marca.MarcaId)
            {
                return BadRequest();
            }

            _context.Entry(existingMarca)
                .CurrentValues
                .SetValues(marca);

            await _context.SaveChangesAsync();

            return Ok(existingMarca);

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

}
