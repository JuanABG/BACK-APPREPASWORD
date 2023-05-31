using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPREPASWORD.Models;

namespace APPREPASWORD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServidorsController : ControllerBase
    {
        private readonly APPREPASWORDContext _context;

        public ServidorsController(APPREPASWORDContext context)
        {
            _context = context;
        }

        // GET: api/Servidors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servidor>>> GetServidors()
        {
          if (_context.Servidors == null)
          {
              return NotFound();
          }
            return await _context.Servidors.ToListAsync();
        }

        // GET: api/Servidors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servidor>> GetServidor(int id)
        {
          if (_context.Servidors == null)
          {
              return NotFound();
          }
            var servidor = await _context.Servidors.FindAsync(id);

            if (servidor == null)
            {
                return NotFound();
            }

            return servidor;
        }

        // PUT: api/Servidors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServidor(int id, Servidor servidor)
        {
            if (id != servidor.Id)
            {
                return BadRequest();
            }

            _context.Entry(servidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServidorExists(id))
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

        // POST: api/Servidors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servidor>> PostServidor(Servidor servidor)
        {
          if (_context.Servidors == null)
          {
              return Problem("Entity set 'APPREPASWORDContext.Servidors'  is null.");
          }
            _context.Servidors.Add(servidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServidor", new { id = servidor.Id }, servidor);
        }

        // DELETE: api/Servidors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServidor(int id)
        {
            if (_context.Servidors == null)
            {
                return NotFound();
            }
            var servidor = await _context.Servidors.FindAsync(id);
            if (servidor == null)
            {
                return NotFound();
            }

            _context.Servidors.Remove(servidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServidorExists(int id)
        {
            return (_context.Servidors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
