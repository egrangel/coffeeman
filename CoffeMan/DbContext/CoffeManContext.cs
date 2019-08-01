using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeManApi.Models
{
    public class CoffeManContext : DbContext
    {
        public CoffeManContext(DbContextOptions<CoffeManContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<AgendamentoUsuario> AgendamentoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEvento> UsuarioEventos { get; set; }
    }
}
