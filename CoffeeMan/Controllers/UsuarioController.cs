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
    public class UsuarioController : ControllerBase
    {
        private readonly CoffeManContext _context;

        public UsuarioController(CoffeManContext context)
        {
            _context = context;

            if (_context.Usuarios.Count() == 0)
            {
                _context.Usuarios.Add(new Usuario { Id = 1, Nome = "Usuario 1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioAsync(long id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuarioAsync(Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioAsync), new { id = Usuario.Id }, Usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuarioAsync(long id, Usuario Usuario)
        {
            if (id != Usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuarioAsync(long id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
