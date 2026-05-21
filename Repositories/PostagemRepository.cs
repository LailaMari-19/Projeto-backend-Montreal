using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly AppDbContext _context;
        public PostagemRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Postagem>> GetAll() => await _context.Postagens.ToListAsync();
        public async Task<Postagem?> GetById(long id) => await _context.Postagens.FindAsync(id);
        public async Task Add(Postagem postagem) => await _context.Postagens.AddAsync(postagem);
        public void Update(Postagem postagem) => _context.Postagens.Update(postagem);
        public void Delete(Postagem postagem) => _context.Postagens.Remove(postagem);
        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}