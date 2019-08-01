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
    public class AgendamentoController : ControllerBase
    {
        private readonly CoffeeManContext _context;

        public AgendamentoController(CoffeeManContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentosAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpGet("{idagendamento}")]
        public async Task<ActionResult<Agendamento>> GetAgendamentoAsync(long idagendamento)
        {
            var agendamento = await _context.Agendamentos.FindAsync(idagendamento);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamentoAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgendamentoAsync), new { idagendamento = agendamento.IdAgendamento }, agendamento);
        }

        [HttpPut("{idagendamento}")]
        public async Task<ActionResult<Agendamento>> PutAgendamentoAsync(long idagendamento, Agendamento agendamento)
        {
            if (idagendamento != agendamento.IdAgendamento)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idagendamento}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamentoAsync(long idagendamento)
        {
            var agendamento = await _context.Agendamentos.FindAsync(idagendamento);

            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
