using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return pagoFounded == null ? NotFound("El pago no se ha encontrado!") : Ok(pagoFounded);

        }

        // POST api/<PagoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pago pago)
        {

            _dbContext.Pago.Add(pago);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = pago.idPago }, pago);

        }

        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pago pago)
        {

            if (id != pago.idPago)
            {
                return BadRequest();
            }

            _dbContext.Entry(pago).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var pago = await _dbContext.Pago.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            _dbContext.Pago.Remove(pago);

            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

        // GET: api/<PagoController>/PagosPorMiembro/5
        [HttpGet("/PagosPorMiembro/{idMiembro}")]
        public async Task<IActionResult> PagosPorMiembro(int idMiembro)
        {

            var pagos = await _dbContext.Pago.Where(p => p.miembroId == idMiembro).ToListAsync();

            if (pagos == null || pagos.Count == 0)
            {
                return NotFound("No se encontraron pagos para este miembro.");
            }

            return Ok(pagos);

        }
    }
}

