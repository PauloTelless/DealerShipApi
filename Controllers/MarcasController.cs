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
        var marcas = await _context
            .Marcas
            .AsNoTracking()
            .ToListAsync();

        return Ok(marcas);
    }

    [HttpPost]
    public async Task<ActionResult<Marca>> PostMarcaAsync(Marca marca)
    {
        _context.Marcas.Add(marca);

        await _context.SaveChangesAsync();

        return Ok(marca);
    }

    [HttpPut("{marcaId}")]
    public async Task<ActionResult<Marca>> PutMarcaAsync(Guid marcaId, Marca marca)
    {
        if (marcaId != marca.MarcaId)
        {
            return BadRequest("MarcaId in the URL does not match the MarcaId in the request body.");
        }

        var existingMarca = await _context.Marcas.FindAsync(marcaId);

        if (existingMarca == null)
        {
            return NotFound();
        }

        // Update the properties of the existingMarca entity with the values from marca
        _context.Entry(existingMarca).CurrentValues.SetValues(marca);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

        return Ok(existingMarca);
    }

}
