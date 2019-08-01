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
        private readonly CoffeManContext _context;

        public EventoController(CoffeManContext context)
        {
            _context = context;

            if (_context.Eventos.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Eventos.Add(new Evento { Id = 1, Descricao = "Evento1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEventoAsync(long id)
        {
            var evento = await _context.Eventos.FindAsync(id);

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

            return CreatedAtAction(nameof(GetEventoAsync), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> PutEventoAsync(long id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEventoAsync(long id)
        {
            var evento = await _context.Eventos.FindAsync(id);

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