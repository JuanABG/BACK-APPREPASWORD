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

            var query = from usu in usuarios

                        select new UsuariosMV
                        {
                            Id = usu.Id,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            NombreArea = usu.Area,
                            Rol = usu.Rol,
                            Estado = usu.Estado,
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

        //to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuariosMV>> PutUsuario(int id, UsuariosMV usuario)
        {
            var usuarioexistente = await _context.Usuarios.FindAsync(id);

            if (usuarioexistente == null)
            {
                return NotFound();
            }

            usuarioexistente.Nombres = usuario.Nombres;
            usuarioexistente.Apellidos = usuario.Apellidos;
            usuarioexistente.Documento = usuario.Documento;
            usuarioexistente.Cargo = usuario.Cargo;
            usuarioexistente.Correo = usuario.Correo;
            usuarioexistente.Telefono = usuario.Telefono;
            usuarioexistente.Fecha = usuario.Fecha;
            usuarioexistente.Area = usuario.NombreArea;
            usuarioexistente.Rol=usuario.Rol;
            usuarioexistente.Estado= usuario.Estado;


            // guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // realizar los joins y obtener la información adicional
            var query = from usu in _context.Usuarios
                        where usu.Id == id
                        select new UsuariosMV
                        {
                            Id = usu.Id,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            NombreArea = usu.Area,
                            Rol = usu.Rol,
                            Estado = usu.Estado,
                            Cargo = usu.Cargo,
                            Telefono = usu.Telefono,
                            Correo = usu.Correo,
                            Fecha = usu.Fecha
                        };

            var usuarioactualizado = await query.FirstOrDefaultAsync();

            return usuarioactualizado;
        }


        [HttpPost]
        public async Task<ActionResult<UsuariosMV>> PostUsuario(UsuariosMV usuario)
        {
            // Verificar si el usuario ya existe en la base de datos
            var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Documento == usuario.Documento);
            if (usuarioExistente != null)
            {
                // Devolver un error de conflicto si el usuario ya existe
                return Conflict("El usuario ya existe en la base de datos.");
            }

            // Crear un nuevo objeto de tipo Usuario
            var nuevoUsuario = new Usuario
            {
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Documento = usuario.Documento,
                Cargo = usuario.Cargo,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Fecha = usuario.Fecha,
                Area = usuario.NombreArea,
                Rol = usuario.Rol,
                Estado = usuario.Estado,
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            // Realizar los joins y obtener la información adicional del usuario creado
            var query = from usu in _context.Usuarios
                        where usu.Id == nuevoUsuario.Id
                        select new UsuariosMV
                        {
                            Id = usu.Id,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            NombreArea = usu.Area,
                            Rol = usu.Rol,
                            Estado = usu.Estado,
                            Cargo = usu.Cargo,
                            Telefono = usu.Telefono,
                            Correo = usu.Correo,
                            Fecha = usu.Fecha
                        };

            var usuarioCreado = await query.FirstOrDefaultAsync();

            // Devolver una respuesta de éxito (201 Created) con el usuario creado
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioCreado.Id }, usuarioCreado);
        }


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

