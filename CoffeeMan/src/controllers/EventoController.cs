using System;
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
    public class EventoController : ControllerBase
    {
        private readonly CoffeeManContext _context;

        public EventoController(CoffeeManContext context)
        {
            _context = context;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Evento/5
        [HttpGet("{idEvento}")]
        public async Task<ActionResult<Evento>> GetEventoAsync(long idEvento)
        {
            var evento = await _context.Eventos.FindAsync(idEvento);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> PostEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventoAsync), new { idEvento = evento.IdEvento }, evento);
        }

        [HttpPut("{idEvento}")]
        public async Task<ActionResult<Evento>> PutEventoAsync(long idEvento, Evento evento)
        {
            if (idEvento != evento.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idEvento}")]
        public async Task<ActionResult<Evento>> DeleteEventoAsync(long idEvento)
        {
            var evento = await _context.Eventos.FindAsync(idEvento);

            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}