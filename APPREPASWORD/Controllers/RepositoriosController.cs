using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPREPASWORD.Models;
using APPREPASWORD.ModelView;
using System.Runtime.ConstrainedExecution;

namespace APPREPASWORD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriosController : ControllerBase
    {
        private readonly APPREPASWORDContext _context;

        public RepositoriosController(APPREPASWORDContext context)
        {
            _context = context;
        }

        // GET: api/Repositorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepositorioMV>>> GetRepositorios()
        {
            var repositorio = await _context.Repositorios.ToListAsync();
            var usuario = await _context.Usuarios.ToListAsync();

            var query = from repo in repositorio
                        join usu in usuario on repo.IdUsuario equals usu.Id

                        select new RepositorioMV
                        {
                            IdRepositorio = repo.IdRepositorio,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Acceso = repo.Acceso,
                            Ambiente = repo.Ambiente,
                            Servidor = repo.Servidor,
                            NombreAcceso = repo.NombreAcceso,
                            Usuario = repo.Usuario,
                            Contraseña = repo.Contraseña,
                            RutaAcceso = repo.RutaAcceso,
                            DetalleRegistro = repo.DetalleRegistro,
                            Estado = repo.Estado,
                            

                        };

            return query.ToList();
        }

        // GET: api/Repositorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repositorio>> GetRepositorio(int id)
        {
          if (_context.Repositorios == null)
          {
              return NotFound();
          }
            var repositorio = await _context.Repositorios.FindAsync(id);

            if (repositorio == null)
            {
                return NotFound();
            }

            return repositorio;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RepositorioMV>> PutRepositorio(int id, RepositorioMV repositorio)
        {
            var repositorioExistente = await _context.Repositorios.FindAsync(id);

            if (repositorioExistente == null)
            {
                return NotFound();
            }

            repositorioExistente.FechaCreacionRegistro = repositorio.FechaCreacionRegistro;
            repositorioExistente.NombreAcceso = repositorio.NombreAcceso;
            repositorioExistente.Usuario = repositorio.Usuario;
            repositorioExistente.Contraseña = repositorio.Contraseña;
            repositorioExistente.RutaAcceso = repositorio.RutaAcceso;
            repositorioExistente.Acceso = repositorio.Acceso;
            repositorioExistente.Ambiente = repositorio.Ambiente;
            repositorioExistente.Servidor = repositorio.Servidor;
            repositorioExistente.DetalleRegistro = repositorio.DetalleRegistro;


            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();



            var query = from repo in _context.Repositorios
                        join usu in _context.Usuarios on repo.IdUsuario equals usu.Id
                        where repo.IdRepositorio == id
                        select new RepositorioMV
                        {
                            IdRepositorio = repo.IdRepositorio,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Acceso = repo.Acceso,
                            Ambiente = repo.Ambiente,
                            Servidor = repo.Servidor,
                            NombreAcceso = repo.NombreAcceso,
                            Usuario = repo.Usuario,
                            Contraseña = repo.Contraseña,
                            RutaAcceso = repo.RutaAcceso,
                            DetalleRegistro = repo.DetalleRegistro,
                            Estado = repo.Estado
                        };
            var repositorioActualizado = await query.FirstOrDefaultAsync();

            return repositorioActualizado;
        }


        //// POST: api/Repositorios
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Repositorio>> PostRepositorio(Repositorio repositorio)
        //{
        //  if (_context.Repositorios == null)
        //  {
        //      return Problem("Entity set 'APPREPASWORDContext.Repositorios'  is null.");
        //  }
        //    _context.Repositorios.Add(repositorio);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRepositorio", new { id = repositorio.IdRepositorio }, repositorio);
        //}

        //// DELETE: api/Repositorios/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRepositorio(int id)
        //{
        //    if (_context.Repositorios == null)
        //    {
        //        return NotFound();
        //    }
        //    var repositorio = await _context.Repositorios.FindAsync(id);
        //    if (repositorio == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Repositorios.Remove(repositorio);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RepositorioExists(int id)
        //{
        //    return (_context.Repositorios?.Any(e => e.IdRepositorio == id)).GetValueOrDefault();
        //}
    }
}
