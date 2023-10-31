using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public PagoController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PagoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Pago> pagos = await _dbContext.Pago.ToListAsync();

            return pagos == null ? BadRequest() : Ok(pagos);

        }

        // GET api/<PagoController>/5
        [HttpGet("{idPago}")]
        public async Task<IActionResult> Get(int idPago)
        {

            Pago pagoFounded = await _dbContext.Pago.SingleOrDefaultAsync(p => p.idPago == idPago);

            return pagoFounded == null ? NotFound("El pago no se ha encontrado o no existe!") : Ok(pagoFounded);

        }

        // POST api/<PagoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pago pago)
        {

            if (pago == null)
            {

                return BadRequest("El pago no se registró correctamente, por favor intente de nuevo!");

            }

            _dbContext.Pago.Add(pago);

            await _dbContext.SaveChangesAsync();

            return Ok(pago);

        }

        // PUT api/<PagoController>/5
        [HttpPut("{idPago}")]
        public async Task<IActionResult> Put(int idPago, [FromBody] Pago newPago)
        {

            Pago pagoToReplace = await _dbContext.Pago.FirstOrDefaultAsync(data => data.idPago == idPago);

            if ( idPago == null || idPago < 0 || pagoToReplace == null)
            {

                return BadRequest("El pago a reemplazar no existe o el nuevo pago tiene errores, por favor intente de nuevo!");

            }

            _dbContext.Entry(newPago).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok(newPago);

        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{idPago}")]
        public async Task<IActionResult> Delete(int idPago)
        {

            Pago pagoToDelete = await _dbContext.Pago.FirstOrDefaultAsync(data => data.idPago == idPago);

            if (pagoToDelete == null)
            {

                return NotFound("El pago a borrar no se ha encontrado!");

            }

            _dbContext.Pago.Remove(pagoToDelete);

            await _dbContext.SaveChangesAsync();

            return Ok("El pago ha sido eliminado exitosamente!");

        }

        // GET: api/<PagoController>/PagosPorMiembro/5
        [HttpGet("/PagosPorMiembro/{idMiembro}")]
        public async Task<IActionResult> PagosPorMiembro(int idMiembro)
        {

            var pagos = await _dbContext.Pago.Where(p => p.miembroId == idMiembro).ToListAsync();

            if (pagos == null || pagos.Count == 0)
            {
                return NotFound("No se encontraron pagos para este miembro!");
            }

            return Ok(pagos);

        }
    }
}

