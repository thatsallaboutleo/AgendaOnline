using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
    }
}
