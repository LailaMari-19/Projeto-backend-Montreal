using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.DTOs
{
    public class UsuarioLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string Senha { get; set; } = string.Empty;
    }
}