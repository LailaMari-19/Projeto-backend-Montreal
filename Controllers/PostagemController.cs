using Microsoft.AspNetCore.Mvc;
using BlogPessoal.Models;
using BlogPessoal.Repositories;

namespace BlogPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemRepository _repository;

        public PostagemController(IPostagemRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Postagem postagem)
        {
            try
            {
                // 1. Garante que sempre exista um Tema e um Usuário válido (ID 1)
                // Se o banco estiver vazio, certifique-se de criar o Tema 1 no Swagger antes!
                if (postagem.TemaId == null || postagem.TemaId == 0) postagem.TemaId = 1;
                if (postagem.UsuarioId == null || postagem.UsuarioId == 0) postagem.UsuarioId = 1;

                // 2. Define a data atual
                postagem.Data = DateTimeOffset.Now;

                // 3. Tenta salvar no banco
                await _repository.Add(postagem);
                await _repository.SaveChanges();
                
                return Ok(postagem);
            }
            catch (Exception ex)
            {
                // 4. Se der erro (como Chave Estrangeira ou conexão), 
                // ele te retorna a mensagem real do erro em vez de um código 500
                var mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest("ERRO AO SALVAR NO BANCO: " + mensagemErro);
            }
        }
    }
}