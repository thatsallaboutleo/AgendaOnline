using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AgendaOnline.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome para o contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite um e-mail para o contato")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite um telefone para o contato")]
        [Phone(ErrorMessage ="O celular informado não é valido")]
        public string Telefone { get; set; }

        [ValidateNever]
        public Usuario usuario { get; set;}
        public int? UsuarioId { get; set; }
    }
}
