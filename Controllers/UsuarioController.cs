using BlogPessoal.Models;
using BlogPessoal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.Controllers
{
    [Route("~/api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuario)
        {
            await _repository.Add(usuario);
            await _repository.SaveChanges();
            return CreatedAtAction(nameof(Cadastrar), usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Update(long id, [FromBody] Usuario usuario)
        {
            usuario.Id = id;
            _repository.Update(usuario);
            await _repository.SaveChanges();
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var usuario = await _repository.GetById(id);
            if (usuario == null) return NotFound();
            _repository.Delete(usuario);
            await _repository.SaveChanges();
            return NoContent();
        }
    }
}