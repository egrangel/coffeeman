using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    public class UsuarioEvento
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long IdEvento { get; set; }
        public long IdUsuario { get; set; }
    }
}
