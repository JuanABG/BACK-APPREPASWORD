using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPREPASWORD.Models;
using APPREPASWORD.ModelView;

namespace APPREPASWORD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly APPREPASWORDContext _context;

        public UsuariosController(APPREPASWORDContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosMV>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var area = await _context.Areas.ToListAsync();
            var rol = await _context.Rols.ToListAsync();
            var estado = await _context.Estados.ToListAsync();

            var query = from usu in usuarios
                        join are in area on usu.IdArea equals are.Id
                        join ro in rol on usu.IdRol equals ro.Id
                        join est in estado on usu.IdEstado equals est.Id

                        select new UsuariosMV
                        {
                            Id = usu.Id,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            NombreArea = are.Nombre,
                            Rol = ro.Nombre,
                            Estado = est.Nombre,
                            Cargo = usu.Cargo,
                            Telefono = usu.Telefono,
                            Correo = usu.Correo,
                            Fecha = usu.Fecha,
                      
                        };

            return query.ToList();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'APPREPASWORDContext.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
