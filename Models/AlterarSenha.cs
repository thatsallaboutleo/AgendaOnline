using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models
{
    public class AlterarSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "Senha não é igual a nova senha")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
