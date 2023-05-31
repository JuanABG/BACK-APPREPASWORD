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
            var acceso = await _context.Accesos.ToListAsync();
            var ambiente = await _context.Ambientes.ToListAsync();
            var servidor = await _context.Servidors.ToListAsync();
            var detalle = await _context.Detalles.ToListAsync();

            var query = from repo in repositorio
                        join usu in usuario on repo.IdUsuario equals usu.Id
                        join acce in acceso on repo.IdAcceso equals acce.Id
                        join amb in ambiente on repo.IdAmbiente equals amb.Id
                        join ser in servidor on repo.IdServidor equals ser.Id
                        join det in detalle on repo.IdDetalleRegistro equals det.Id

                        select new RepositorioMV
                        {
                            IdRepositorio = repo.IdRepositorio,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres  = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Acceso = acce.Nombre,
                            Ambiente = amb.Nombre,
                            Servidor = ser.Nombre,
                            NombreAcceso = repo.NombreAcceso,
                            Usuario = repo.Usuario,
                            Contraseña = repo.Contraseña,
                            RutaAcceso = repo.RutaAcceso,
                            DetalleRegistro = det.Detalle1,

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

        // PUT: api/Repositorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepositorio(int id, Repositorio repositorio)
        {
            if (id != repositorio.IdRepositorio)
            {
                return BadRequest();
            }

            _context.Entry(repositorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepositorioExists(id))
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

        // POST: api/Repositorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repositorio>> PostRepositorio(Repositorio repositorio)
        {
          if (_context.Repositorios == null)
          {
              return Problem("Entity set 'APPREPASWORDContext.Repositorios'  is null.");
          }
            _context.Repositorios.Add(repositorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepositorio", new { id = repositorio.IdRepositorio }, repositorio);
        }

        // DELETE: api/Repositorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepositorio(int id)
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

            _context.Repositorios.Remove(repositorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepositorioExists(int id)
        {
            return (_context.Repositorios?.Any(e => e.IdRepositorio == id)).GetValueOrDefault();
        }
    }
}
