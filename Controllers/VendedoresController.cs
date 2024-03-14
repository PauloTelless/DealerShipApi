using DealerShipApi.Context;
using DealerShipApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Controllers;

[Route("[controller]")]
[ApiController]
public class VendedoresController : ControllerBase
{
    private readonly DealerShipAppContext _context;

    public VendedoresController(DealerShipAppContext context)
    {
        _context = context; 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedoresAsync()
    {
        try
        {
            var vendedores = await _context
                .Vendedores
                .ToListAsync();

            return Ok(vendedores);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);      
        }
    }

    [HttpGet("VendedoresCarros")]   
    public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedoresCarros()
    {
        try
        {
            var vendedoresCarros = await _context.Vendedores
                .Include(carros => carros.Carros)
                .AsNoTracking()
                .ToListAsync();

            return Ok(vendedoresCarros);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }


    [HttpPost]  
    public async Task<ActionResult<Vendedor>> PostVendedorAsync(Vendedor vendedor)
    {
        try
        {
            _context.Vendedores.Add(vendedor);  

            await _context.SaveChangesAsync();

            return Ok(vendedor);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{vendedorId}")]
    public async Task<ActionResult<Vendedor>> PutVendedor(Vendedor vendedor, Guid vendedorId)
    {
        try
        {
            if (vendedor.VendedorId.ToString() != vendedorId.ToString())
            {
                return NotFound();  
            }

            _context.Vendedores.Entry(vendedor).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return vendedor;
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{vendedorId}")]
    public async Task<ActionResult<Vendedor>> DeleteVendedorAsync(Guid vendedorId)
    {
        var vendedorFiltrado = await _context
            .Vendedores
            .FirstOrDefaultAsync(vendedor => vendedor.VendedorId.ToString() == vendedorId.ToString());

        if (vendedorFiltrado == null)
        {
            return NotFound();
        }

        _context.Vendedores.Remove(vendedorFiltrado);

        await _context.SaveChangesAsync();

        return vendedorFiltrado;
    }
}
