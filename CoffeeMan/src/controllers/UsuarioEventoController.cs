using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeManApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEventoController : ControllerBase
    {
        private readonly CoffeeManContext _context;

        public UsuarioEventoController(CoffeeManContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEvento>>> GetUsuarioEventosAsync()
        {
            return await _context.UsuarioEventos.ToListAsync();
        }

        [HttpGet("{idUsuarioEvento}")]
        public async Task<ActionResult<UsuarioEvento>> GetUsuarioEventoAsync(long idUsuarioEvento)
        {
            var UsuarioEvento = await _context.UsuarioEventos.FindAsync(idUsuarioEvento);

            if (UsuarioEvento == null)
            {
                return NotFound();
            }

            return UsuarioEvento;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioEvento>> PostUsuarioEventoAsync(UsuarioEvento UsuarioEvento)
        {
            _context.UsuarioEventos.Add(UsuarioEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioEventoAsync), new { idUsuarioEvento = UsuarioEvento.IdUsuarioEvento }, UsuarioEvento);
        }

        [HttpPut("{idUsuarioEvento}")]
        public async Task<ActionResult<UsuarioEvento>> PutUsuarioEventoAsync(long idUsuarioEvento, UsuarioEvento UsuarioEvento)
        {
            if (idUsuarioEvento != UsuarioEvento.IdUsuarioEvento)
            {
                return BadRequest();
            }

            _context.Entry(UsuarioEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idUsuarioEvento}")]
        public async Task<ActionResult<UsuarioEvento>> DeleteUsuarioEventoAsync(long idUsuarioEvento)
        {
            var UsuarioEvento = await _context.UsuarioEventos.FindAsync(idUsuarioEvento);

            if (UsuarioEvento == null)
            {
                return NotFound();
            }

            _context.UsuarioEventos.Remove(UsuarioEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
