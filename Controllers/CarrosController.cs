using DealerShipApi.Context;
using DealerShipApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealerShipApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CarrosController : ControllerBase
{
    private readonly DealerShipAppContext _context;

    public CarrosController(DealerShipAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carro>>> GetCarrosAsync()
    {
        try
        {
            var carros = await _context
                .Carros
                .AsNoTracking() 
                .ToListAsync();

            return Ok(carros);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet("CarrosCategoriasVendedores")]
    public async Task<ActionResult<IEnumerable<Carro>>> GetCarroVendedor()
    {
        var carros = await _context
            .Carros
            .Include(c => c.Categoria)
            .Include(p => p.Vendedor)
            .AsNoTracking()
            .ToListAsync();

        return Ok(carros);
    }

    [HttpPost]
    public async Task<ActionResult<Carro>> PostCarroAsync(Carro carro)
    {
        try
        {
            _context.Carros.Add(carro);

            await _context.SaveChangesAsync();

            return Ok(carro);

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{carroId}")]   
    public async Task<ActionResult<Carro>> PutCarroAsync(Carro carro, Guid carroId)
    {
        try
        {
            if (carro.CarroId.ToString() != carroId.ToString())
            {
                return NotFound();
            }

            _context.Carros.Entry(carro).State = EntityState.Modified;      

            await _context.SaveChangesAsync();      

            return carro;   
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    [HttpDelete("{carroId}")]
    public async Task<ActionResult<Carro>> DeleteCarroAsync(Guid carroId)
    {
        try
        {
            var carroFiltrado = await _context
                .Carros
                .FirstOrDefaultAsync(carro => carro.CarroId.ToString() == carroId.ToString());

            if (carroFiltrado == null)
            { 
                return NotFound(); 
            }              

            _context.Carros.Remove(carroFiltrado);
            
            await _context.SaveChangesAsync();

            return Ok(carroFiltrado);
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

}
