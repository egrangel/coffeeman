using CoffeeManApi.Enumerados;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeManApi.Models
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "int")]
        public EnumUsuarioPerfil Perfil { get; set; }
        [Column(TypeName = "int")]
        public bool Ativo { get; set; }
    }
}
