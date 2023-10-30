using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public MembresiaController (ApplicationDBContext dBContext)
        {

            _dbContext = dBContext;

        }

        // GET: api/<MembresiaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Membresia> membresias = await _dbContext.Membresia.ToListAsync();

            return membresias == null ? BadRequest("Hubo un error al consultar las membresías!") : Ok(membresias);

        }

        // GET api/<MembresiaController>/5
        [HttpGet("{idMembresia}")]
        public async Task<IActionResult> Get(int idMembresia)
        {

            Membresia membresiaFounded = await _dbContext.Membresia.FirstOrDefaultAsync(data => data.idMembresia == idMembresia);

            return membresiaFounded == null ? BadRequest() : Ok(membresiaFounded);

        }

        // GET api/<MembresiaController>/5
        [HttpGet("/MiembrosDeUnaMembresia/{idMembresia}")]
        public async Task<IActionResult> GetMiembrosDeUnaMembresia(int idMembresia)
        {

            Membresia membresiaConMiembrosFounded = await _dbContext.Membresia
                .Include(data => data.Miembros)
                .SingleOrDefaultAsync(data => data.idMembresia == idMembresia);

            return membresiaConMiembrosFounded == null ? BadRequest() : Ok(membresiaConMiembrosFounded);

        }

        // Renovar membresia
        [HttpGet("/RenovarMembresia/{idMiembro}")]
        public async Task<IActionResult> RenovarMembresia(int idMiembro)
        {
            // Buscar el miembro
            Miembro miembro = await _dbContext.Miembro
                .SingleOrDefaultAsync(data => data.idMiembro == idMiembro);

            // Si el miembro no existe, devolver BadRequest
            if (miembro == null)
            {
                return BadRequest("El miembro no existe!");
            }

            // Buscar la membresía del miembro
            Membresia membresia = await _dbContext.Membresia
                .SingleOrDefaultAsync(data => data.idMembresia == miembro.idMembresia);

            // Si la membresía no existe, devolver BadRequest
            if (membresia == null)
            {
                return BadRequest($"La membresía del miembro {miembro.nombreMiembro} no existe!");
            }

            // Si todo está bien, devolver Ok
            return Ok($"La membresía del miembro {miembro.nombreMiembro} ha sido renovada con éxito!");
        }

        // Eliminar membresia
        [HttpDelete("/EliminarMembresia/{idMiembro}")]
        public async Task<IActionResult> EliminarMembresia(int idMiembro)
        {
            // Buscar el miembro
            Miembro miembro = await _dbContext.Miembro
                .Include(m => m.Membresia)
                .SingleOrDefaultAsync(m => m.idMiembro == idMiembro);

            // Si el miembro no existe, devolver BadRequest
            if (miembro == null)
            {
                return BadRequest("El miembro no existe.");
            }

            // Comprobar si el miembro tiene una membresía
            if (miembro.idMembresia == null || miembro.idMembresia == -1)
            {
                return BadRequest("El miembro no tiene una membresía.");
            }

            // Eliminar la membresía del miembro
            miembro.idMembresia = -1;

            // Guardar los cambios en la base de datos
            await _dbContext.SaveChangesAsync();

            // Si todo está bien, devolver Ok
            return Ok("La membresía ha sido cancelada con éxito.");
        }


        // POST api/<MembresiaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Membresia newMembresia)
        {

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            Membresia membresiaFounded = await _dbContext.Membresia.FirstOrDefaultAsync(data => data.idMembresia == newMembresia.idMembresia);

            if (newMembresia == null || membresiaFounded != null)
            {

                return BadRequest("La nueva membresía tiene errores o ya existe la membresía a registrar!");

            }

            await _dbContext.Membresia.AddAsync(newMembresia);
            await _dbContext.SaveChangesAsync();

            return Ok(newMembresia);

        }

        // PUT api/<MembresiaController>/5
        [HttpPut("{idMembresia}")]
        public async Task<IActionResult> Put(int idMembresia, [FromBody] Membresia newMembresia)
        {

            Membresia membresiaToReplace = await _dbContext.Membresia.FirstOrDefaultAsync(data => data.idMembresia == idMembresia);

            if (newMembresia == null || membresiaToReplace == null)
            {

                return BadRequest("La nueva membresía tiene errores o no existe la membresía a reemplazar!");

            }

            membresiaToReplace.nombreMembresia = newMembresia.nombreMembresia == null ? membresiaToReplace.nombreMembresia : newMembresia.nombreMembresia;
            membresiaToReplace.precioMembresia = newMembresia.precioMembresia == null ? membresiaToReplace.precioMembresia : newMembresia.precioMembresia;
            membresiaToReplace.duracionMembresia = newMembresia.duracionMembresia == null ? membresiaToReplace.duracionMembresia : newMembresia.duracionMembresia;

            await _dbContext.SaveChangesAsync();

            return Ok(membresiaToReplace);

        }

        // DELETE api/<MembresiaController>/5
        [HttpDelete("{idMembresia}")]
        public async Task<IActionResult> Delete(int idMembresia)
        {

            Membresia membresiaToDelete = await _dbContext.Membresia.FirstOrDefaultAsync(data => data.idMembresia == idMembresia);

            if (membresiaToDelete == null)
            {

                return BadRequest("No se ha encontrado le membresía a borrar!");

            }

            _dbContext.Remove(membresiaToDelete);

            await _dbContext.SaveChangesAsync();

            return Ok("La membresía ha sido eliminada correctamente!");

        }
    }
}
