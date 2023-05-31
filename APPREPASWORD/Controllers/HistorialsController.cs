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
            var acceso = await _context.Accesos.ToListAsync();
            var ambiente = await _context.Ambientes.ToListAsync();
            var servidor = await _context.Servidors.ToListAsync();
            var detalle = await _context.Detalles.ToListAsync();
            var area = await _context.Areas.ToListAsync();
            var rol = await _context.Rols.ToListAsync();
            var estado = await _context.Estados.ToListAsync();

            var query = from hist in historial
                        join repo in repositorio on hist.Usuario equals repo.Usuario
                        join usu in usuario on hist.IdUsuario equals usu.Id
                        join acce in acceso on hist.IdAcceso equals acce.Id
                        join amb in ambiente on hist.IdAmbiente equals amb.Id
                        join ser in servidor on hist.IdServidor equals ser.Id
                        join det in detalle on hist.IdDetalleRegistro equals det.Id
                        join are in area on hist.Id equals are.Id
                        join ro in rol on hist.Id equals ro.Id
                        join est in estado on hist.Id equals est.Id

                        select new HistorialMV
                        {
                            Id = hist.Id,
                            FechaNovedad = hist.FechaNovedad,
                            IdRepositorio = hist.IdRegistro,
                            FechaCreacionRegistro = repo.FechaCreacionRegistro,
                            Nombres = usu.Nombres,
                            Apellidos = usu.Apellidos,
                            Documento = usu.Documento,
                            Cargo = usu.Cargo,
                            Rol = ro.Nombre,
                            NombreArea = are.Nombre,
                            Estado = est.Nombre,
                            Acceso = acce.Nombre,
                            Ambiente = amb.Nombre,
                            Servidor =ser.Nombre,
                            RutaAcceso = repo.RutaAcceso,
                            Usuario = repo.Usuario,
                            NombreAcceso = repo.NombreAcceso,
                            DetalleRegistro = det.Detalle1,
                            Comentarios = hist.Comentarios

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
        public async Task<IActionResult> PutHistorial(int id, Historial historial)
        {
            if (id != historial.Id)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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
