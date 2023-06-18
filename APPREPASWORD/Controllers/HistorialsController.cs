using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPREPASWORD.Models;
using APPREPASWORD.ModelView;
using NuGet.Protocol.Core.Types;

namespace APPREPASWORD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly APPREPASWORDContext _context;

        public HistorialsController(APPREPASWORDContext context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMV>>> GetHistorials()
        {
            var historial = await _context.Historials.ToListAsync();
            var repositorio = await _context.Repositorios.ToListAsync();
            var usuario = await _context.Usuarios.ToListAsync();
  

            var query = from hist in historial
                        join repo in repositorio on hist.IdRegistro equals repo.IdRepositorio
                        join usu in usuario on hist.IdUsuario equals usu.Id

                        select new HistorialMV
                        {
                            Id = hist.Id,
                            FechaNovedad = hist.FechaNovedad,
                            IdRepositorio = repo.IdRepositorio,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Cargo = usu.Cargo,
                            Rol = usu.Rol,
                            NombreArea = usu.Area,                  
                            Acceso = repo.Acceso,
                            Ambiente = repo.Ambiente,
                            Servidor =repo.Servidor,
                            RutaAcceso = repo.RutaAcceso,
                            Usuario = repo.Usuario,
                            NombreAcceso = repo.NombreAcceso,
                            DetalleRegistro = repo.DetalleRegistro,
                            Comentarios = hist.Comentarios,
                            Estado = usu.Estado,

                        };

            return query.ToList();
        }

        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
          if (_context.Historials == null)
          {
              return NotFound();
          }
            var historial = await _context.Historials.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // PUT: api/Historials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<HistorialMV>> PutRepositorio(int id, HistorialMV historial)
        {
            var historialExistente = await _context.Historials.FindAsync(id);

            if (historialExistente == null)
            {
                return NotFound();
            }

            historialExistente.FechaNovedad = historial.FechaNovedad;
            historialExistente.IdRegistro = historial.IdRepositorio;
            historialExistente.Comentarios = historial.Comentarios;

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            var query = from hist in _context.Historials
                        join repo in _context.Repositorios on hist.Usuario equals repo.Usuario
                        join usu in _context.Usuarios on hist.IdUsuario equals usu.Id
               
                        select new HistorialMV
                        {
                            Id = hist.Id,
                            FechaNovedad = hist.FechaNovedad,
                            IdRepositorio = repo.IdRepositorio,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Cargo = usu.Cargo,
                            Rol = usu.Rol,
                            NombreArea = usu.Area,
                            Acceso = repo.Acceso,
                            Ambiente = repo.Ambiente,
                            Servidor = repo.Servidor,
                            RutaAcceso = repo.RutaAcceso,
                            Usuario = repo.Usuario,
                            NombreAcceso = repo.NombreAcceso,
                            DetalleRegistro = repo.DetalleRegistro,
                            Comentarios = hist.Comentarios,
                            Estado = usu.Estado,
                        };
            var historialActualizado = await query.FirstOrDefaultAsync();

            return historialActualizado;
        }

        // POST: api/Historials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial historial)
        {
          if (_context.Historials == null)
          {
              return Problem("Entity set 'APPREPASWORDContext.Historials'  is null.");
          }
            _context.Historials.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorial", new { id = historial.Id }, historial);
        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            if (_context.Historials == null)
            {
                return NotFound();
            }
            var historial = await _context.Historials.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historials.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialExists(int id)
        {
            return (_context.Historials?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
