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
    public class AgendamentoController : ControllerBase
    {
        private readonly CoffeManContext _context;

        public AgendamentoController(CoffeManContext context)
        {
            _context = context;

            if (_context.Agendamentos.Count() == 0)
            {
                _context.Agendamentos.Add(new Agendamento { Id = 1, Descricao = "Agendamento 1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentosAsync()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamentoAsync(long id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

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

            return CreatedAtAction(nameof(GetAgendamentoAsync), new { id = agendamento.Id }, agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Agendamento>> PutAgendamentoAsync(long id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamentoAsync(long id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);

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
