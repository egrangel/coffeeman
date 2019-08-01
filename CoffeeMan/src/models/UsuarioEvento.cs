using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManApi.Models
{
    [Table("UsuarioEvento", Schema = "dbo")]
    public class UsuarioEvento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUsuarioEvento { get; set; }
        public string Descricao { get; set; }
        public long IdEvento { get; set; }
        public long IdUsuario { get; set; }
    }
}
