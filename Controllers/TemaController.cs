using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogPessoal.Data;
using BlogPessoal.Models;

namespace BlogPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TemaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetAll()
        {
            return await _context.Temas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetById(long id)
        {
            var tema = await _context.Temas.FindAsync(id);
            if (tema == null) return NotFound();
            return tema;
        }

        [HttpPost]
        public async Task<ActionResult<Tema>> Post(Tema tema)
        {
            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tema.Id }, tema);
        }

        [HttpPut]
        public async Task<ActionResult<Tema>> Put(Tema tema)
        {
            _context.Temas.Update(tema);
            await _context.SaveChangesAsync();
            return Ok(tema);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var tema = await _context.Temas.FindAsync(id);
            if (tema == null) return NotFound();

            _context.Temas.Remove(tema);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}