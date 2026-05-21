using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPessoal.Models
{
    public class Postagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Texto { get; set; } = string.Empty;

        public DateTimeOffset Data { get; set; } = DateTimeOffset.Now;

        public string? ResumoIA { get; set; }
        public string? TagsIA { get; set; }
        public string? CategoriaIA { get; set; }

        public virtual Tema? Tema { get; set; }
        [ForeignKey("Tema")]
        public long? TemaId { get; set; } // O '?' aqui é obrigatório

        public virtual Usuario? Usuario { get; set; }
        [ForeignKey("Usuario")]
        public long? UsuarioId { get; set; }
    }
}