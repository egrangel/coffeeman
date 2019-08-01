using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    [Table("Evento", Schema = "dbo")]
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }

    }
}
