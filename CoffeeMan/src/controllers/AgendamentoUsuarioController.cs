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
    public class AgendamentoUsuarioController : ControllerBase
    {
        private readonly CoffeeManContext _context;

        public AgendamentoUsuarioController(CoffeeManContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoUsuario>>> GetAgendamentoUsuariosAsync()
        {
            return await _context.AgendamentoUsuarios.ToListAsync();
        }

        [HttpGet("{idAgendamentoUsuario}")]
        public async Task<ActionResult<AgendamentoUsuario>> GetAgendamentoUsuarioAsync(long idAgendamentoUsuario)
        {
            var AgendamentoUsuario = await _context.AgendamentoUsuarios.FindAsync(idAgendamentoUsuario);

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

            return CreatedAtAction(nameof(GetAgendamentoUsuarioAsync), new { idAgendamentoUsuario = AgendamentoUsuario.IdAgendamentoUsuario }, AgendamentoUsuario);
        }

        [HttpPut("{idAgendamentoUsuario}")]
        public async Task<ActionResult<AgendamentoUsuario>> PutAgendamentoUsuarioAsync(long idAgendamentoUsuario, AgendamentoUsuario AgendamentoUsuario)
        {
            if (idAgendamentoUsuario != AgendamentoUsuario.IdAgendamentoUsuario)
            {
                return BadRequest();
            }

            _context.Entry(AgendamentoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idAgendamentoUsuario}")]
        public async Task<ActionResult<AgendamentoUsuario>> DeleteAgendamentoUsuarioAsync(long idAgendamentoUsuario)
        {
            var AgendamentoUsuario = await _context.AgendamentoUsuarios.FindAsync(idAgendamentoUsuario);

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
