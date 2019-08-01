using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    public class Agendamento
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long IdEvento { get; set; }
        public DateTime DataAgendadmento { get; set; }

    }
}
