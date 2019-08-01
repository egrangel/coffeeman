using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeManApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEventoController : ControllerBase
    {
        private readonly CoffeManContext _context;

        public UsuarioEventoController(CoffeManContext context)
        {
            _context = context;

            if (_context.UsuarioEventos.Count() == 0)
            {
                _context.UsuarioEventos.Add(new UsuarioEvento { Id = 1, Descricao = "UsuarioEvento 1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEvento>>> GetUsuarioEventosAsync()
        {
            return await _context.UsuarioEventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEvento>> GetUsuarioEventoAsync(long id)
        {
            var UsuarioEvento = await _context.UsuarioEventos.FindAsync(id);

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

            return CreatedAtAction(nameof(GetUsuarioEventoAsync), new { id = UsuarioEvento.Id }, UsuarioEvento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioEvento>> PutUsuarioEventoAsync(long id, UsuarioEvento UsuarioEvento)
        {
            if (id != UsuarioEvento.Id)
            {
                return BadRequest();
            }

            _context.Entry(UsuarioEvento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioEvento>> DeleteUsuarioEventoAsync(long id)
        {
            var UsuarioEvento = await _context.UsuarioEventos.FindAsync(id);

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
