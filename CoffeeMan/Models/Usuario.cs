using CoffeeManApi.Enumerados;

namespace CoffeeManApi.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnumUsuarioPerfil Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}
