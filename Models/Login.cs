using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
