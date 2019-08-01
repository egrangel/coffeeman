using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    public class CoffeeManContext : DbContext
    {
        public CoffeeManContext(DbContextOptions<CoffeeManContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioEvento> UsuarioEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"PG_CONNECTION_STRING_SQLSERVER");
            }
        }
    }
}
