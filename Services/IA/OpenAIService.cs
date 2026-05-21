using BlogPessoal.DTOs;

namespace BlogPessoal.Services.IA
{
    public class OpenAIService : IIAService
    {
        public async Task<ResultadoIA> GerarResumoAsync(string conteudo)
        {
            await Task.Delay(500); 

            return new ResultadoIA
            {
                Resumo = "Resumo gerado com sucesso.",
                Tags = "IA, C#, DTO",
                Categoria = "Geral"
            };
        }
    }
}