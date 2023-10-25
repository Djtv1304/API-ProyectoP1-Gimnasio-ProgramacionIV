using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public MiembroController(ApplicationDBContext dbContext)
        {
            // Inyección de dependencias, inyecto la dependencia de la DB
            _dbContext = dbContext;

        }



        // GET: api/<MiembroController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Miembro> miembros = await _dbContext.Miembro.ToListAsync();

            return Ok(miembros);
        }

        // GET api/<MiembroController>/5
        [HttpGet("{idMiembro}")]
        public async Task<IActionResult> Get(int idMiembro)
        {

            Miembro miembroFounded = await _dbContext.Miembro.FirstOrDefaultAsync( data => data.idMiembro == idMiembro);

            return miembroFounded == null ? BadRequest() : Ok(miembroFounded);

        }

        // POST api/<MiembroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Miembro newMiembro)
        {

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            Miembro miembroFounded = await _dbContext.Miembro.FirstOrDefaultAsync(x => x.idMiembro == newMiembro.idMiembro);

            if (newMiembro == null || miembroFounded != null)
            {

                return BadRequest("El nuevo miembro tiene errores o ya existe el miembro a registrar!");

            }

            await _dbContext.Miembro.AddAsync(newMiembro);
            await _dbContext.SaveChangesAsync();

            return Ok(newMiembro);

        }

        // PUT api/<MiembroController>/5
        [HttpPut("{idMiembroToReplace}")]
        public async Task<IActionResult> Put(int idMiembroToReplace, [FromBody] Miembro newMiembro)
        {

            Miembro miembroToReplace = await _dbContext.Miembro.FirstOrDefaultAsync(data => data.idMiembro == idMiembroToReplace);

            if (newMiembro == null || miembroToReplace == null)
            {

                return BadRequest("El nuevo miembro tiene errores o no existe el miembro a reemplazar!");

            }

            miembroToReplace.nombreMiembro = newMiembro.nombreMiembro == null ? miembroToReplace.nombreMiembro : newMiembro.nombreMiembro;
            miembroToReplace.apellidoMiembro = newMiembro.apellidoMiembro == null ? miembroToReplace.apellidoMiembro : newMiembro.nombreMiembro;
            miembroToReplace.emailMiembro = newMiembro.emailMiembro == null ? miembroToReplace.apellidoMiembro: newMiembro.emailMiembro;
            miembroToReplace.fechaInscripcion = newMiembro.fechaInscripcion == null ? miembroToReplace.fechaInscripcion: newMiembro.fechaInscripcion;

            await _dbContext.SaveChangesAsync();

            return Ok(miembroToReplace);

        }

        // DELETE api/<MiembroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int idMiembroToDelete)
        {

            Miembro miembroToDelete = await _dbContext.Miembro.FirstOrDefaultAsync( data => data.idMiembro == idMiembroToDelete );

            if (miembroToDelete == null ) 
            { 
            
                return BadRequest();

            }

            _dbContext.Remove(miembroToDelete);

            await _dbContext.SaveChangesAsync();

            return Ok("El miembro ha sido eliminado correctamente!");

        }
    }
}
