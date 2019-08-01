using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeManApi.Models
{
    public class Evento
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }

    }
}
