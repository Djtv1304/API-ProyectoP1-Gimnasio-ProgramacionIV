﻿using API_ProyectoP1_Gimnasio_ProgramacionIV.Data;
using API_ProyectoP1_Gimnasio_ProgramacionIV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ProyectoP1_Gimnasio_ProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public UsuariosController(ApplicationDBContext dbContext)
        {
            // Inyección de dependencias, inyecto la dependencia de la DB
            _dbContext = dbContext;

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Usuario> usuarios = await _dbContext.Usuarios.ToListAsync();

            return usuarios == null ? BadRequest() : Ok(usuarios);

        }

        // POST api/<MiembroController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {

            // En caso de que el framework no valide que ya exista un ID que ya existe debemos validar nosotros
            Usuario usuarioEncontrado = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == usuario.idUsuario);

            if (usuario == null || usuarioEncontrado != null)
            {

                return BadRequest("El usuario ya está registrado o ocurrió un error!");

            }

            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return Ok(usuario);

        }
    }
}