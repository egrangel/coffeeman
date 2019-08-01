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
        private readonly CoffeeManContext _context;

        public UsuarioController(CoffeeManContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetUsuarioAsync(long idUsuario)
        {
            var Usuario = await _context.Usuarios.FindAsync(idUsuario);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuarioAsync([FromBody]Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarioAsync), new { idUsuario = Usuario.IdUsuario }, Usuario);
        }

        [HttpPut("{idUsuario}")]
        public async Task<ActionResult<Usuario>> PutUsuarioAsync(long idUsuario, Usuario Usuario)
        {
            if (idUsuario != Usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(Usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult<Usuario>> DeleteUsuarioAsync(long idUsuario)
        {
            var Usuario = await _context.Usuarios.FindAsync(idUsuario);

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
