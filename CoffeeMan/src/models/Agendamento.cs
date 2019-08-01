using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    [Table("Agendamento", Schema = "dbo")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAgendamento { get; set; }
        public string Descricao { get; set; }
        public long IdEvento { get; set; }
        public DateTime DataAgendamento { get; set; }

    }
}
