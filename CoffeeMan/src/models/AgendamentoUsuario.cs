using CoffeeManApi.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    [Table("AgendamentoUsuario", Schema = "dbo")]
    public class AgendamentoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAgendamentoUsuario { get; set; }
        public string Descricao { get; set; }
        public long IdAgendamento { get; set; }
        public long IdUsuario { get; set; }
        public DateTime HoraAgendamento { get; set; }

        [Column(TypeName = "int")]
        public EnumAgendamentoStatus Status { get; set; }
    }
}
