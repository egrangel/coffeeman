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
    public class AgendamentoUsuarioController : ControllerBase
    {
        private readonly CoffeManContext _context;

        public AgendamentoUsuarioController(CoffeManContext context)
        {
            _context = context;

            if (_context.AgendamentoUsuarios.Count() == 0)
            {
                _context.AgendamentoUsuarios.Add(new AgendamentoUsuario { Id = 1, Descricao = "AgendamentoUsuario 1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoUsuario>>> GetAgendamentoUsuariosAsync()
        {
            return await _context.AgendamentoUsuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoUsuario>> GetAgendamentoUsuarioAsync(long id)
        {
            var AgendamentoUsuario = await _context.AgendamentoUsuarios.FindAsync(id);

            if (AgendamentoUsuario == null)
            {
                return NotFound();
            }

            return AgendamentoUsuario;
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoUsuario>> PostAgendamentoUsuarioAsync(AgendamentoUsuario AgendamentoUsuario)
        {
            _context.AgendamentoUsuarios.Add(AgendamentoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamentoUsuarioAsync), new { id = AgendamentoUsuario.Id }, AgendamentoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgendamentoUsuario>> PutAgendamentoUsuarioAsync(long id, AgendamentoUsuario AgendamentoUsuario)
        {
            if (id != AgendamentoUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(AgendamentoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AgendamentoUsuario>> DeleteAgendamentoUsuarioAsync(long id)
        {
            var AgendamentoUsuario = await _context.AgendamentoUsuarios.FindAsync(id);

            if (AgendamentoUsuario == null)
            {
                return NotFound();
            }

            _context.AgendamentoUsuarios.Remove(AgendamentoUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
