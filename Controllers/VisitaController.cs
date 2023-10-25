using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitaController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public VisitaController (ApplicationDBContext dbContext)
        {

            _dbContext = dbContext;

        }

        // GET: api/<VisitaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Visita> listaVisitas = await _dbContext.Visita.ToListAsync();

            return listaVisitas == null ? BadRequest() : Ok(listaVisitas);

        }

        [HttpGet("/VisitasPorMiembro/{idMiembro}")]
        public async Task<IActionResult> GetVisitasByMiembro(int idMiembro)
        {
            try
            {
                // Utilizo Entity Framework para consultar las visitas asociadas a un miembro mediante su ID
                var visitas = await _dbContext.Visita
                    .Where(v => v.miembroId == idMiembro)
                    .ToListAsync();

                return Ok(visitas);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


        // GET api/<VisitaController>/5
        [HttpGet("{idVisita}")]
        public async Task<IActionResult> Get(int idVisita)
        {

            Visita visitaFounded = await _dbContext.Visita.FirstOrDefaultAsync(data => data.idVisita == idVisita);

            return visitaFounded == null ? BadRequest() : Ok(visitaFounded);

        }

        // POST api/<VisitaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Visita newVisita)
        {

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            Visita visitaFounded = await _dbContext.Visita.FirstOrDefaultAsync(x => x.idVisita == newVisita.idVisita);

            if (newVisita == null || visitaFounded != null)
            {

                return BadRequest("La nueva visita tiene errores o ya existe una visita con los mismos datos!");

            }

            await _dbContext.Visita.AddAsync(newVisita);
            await _dbContext.SaveChangesAsync();

            return Ok(newVisita);

        }

        // PUT api/<VisitaController>/5
        [HttpPut("{idVisita}")]
        public async Task<IActionResult> Put(int idVisita, [FromBody] Visita newVisita)
        {

            Visita visitaToReplace = await _dbContext.Visita.FirstOrDefaultAsync(data => data.idVisita == idVisita);

            if (newVisita == null || visitaToReplace == null)
            {

                return BadRequest("La nueva visita tiene errores o no existe la visita a reemplazar!");

            }

            visitaToReplace.fechaVisita = newVisita.fechaVisita == null ? visitaToReplace.fechaVisita : newVisita.fechaVisita;
            visitaToReplace.miembroId = newVisita.miembroId == null ? visitaToReplace.miembroId : newVisita.miembroId;
            visitaToReplace.descripcionVisita = newVisita.descripcionVisita == null ? visitaToReplace.descripcionVisita : newVisita.descripcionVisita;

            await _dbContext.SaveChangesAsync();

            return Ok(visitaToReplace);

        }

        // DELETE api/<VisitaController>/5
        [HttpDelete("{idVisita}")]
        public async Task<IActionResult> Delete(int idVisita)
        {

            Visita visitaToDelete = await _dbContext.Visita.FirstOrDefaultAsync(data => data.idVisita == idVisita);

            if (visitaToDelete == null)
            {

                return BadRequest("No se encontró la visita a eliminar!");

            }

            _dbContext.Remove(visitaToDelete);

            await _dbContext.SaveChangesAsync();

            return Ok("La visita ha sido eliminado correctamente!");

        }
    }
}
