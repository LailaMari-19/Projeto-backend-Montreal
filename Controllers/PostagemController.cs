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
              
                if (postagem.TemaId == null || postagem.TemaId == 0) postagem.TemaId = 1;
                if (postagem.UsuarioId == null || postagem.UsuarioId == 0) postagem.UsuarioId = 1;

                postagem.Data = DateTimeOffset.Now;

              
                await _repository.Add(postagem);
                await _repository.SaveChanges();
                
                return Ok(postagem);
            }
            catch (Exception ex)
            {
               
                var mensagemErro = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest("ERRO AO SALVAR NO BANCO: " + mensagemErro);
            }
        }
    }
}
