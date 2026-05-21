namespace BlogPessoal.DTOs
{
    public class PostagemDTO
    {
        public long Id { get; set; }
        
        public string Titulo { get; set; } = string.Empty;
        
        public string Texto { get; set; } = string.Empty;
        
        public DateTimeOffset Data { get; set; } = DateTimeOffset.Now;
        
        public long TemaId { get; set; }
        
        // Estes campos serão preenchidos pela IA posteriormente
        public string? ResumoIA { get; set; }
        public string? TagsIA { get; set; }
        public string? CategoriaIA { get; set; }
    }
}