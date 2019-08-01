using CoffeManApi.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeManApi.Models
{
    public class AgendamentoUsuario
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long IdAgendamento { get; set; }
        public long IdUsuario { get; set; }
        public DateTime HoraAgendamento { get; set; }
        public EnumAgendamentoStatus Status { get; set; }
    }
}
