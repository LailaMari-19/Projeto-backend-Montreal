using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories
{
    public class TemaRepository : ITemaRepository
    {
        private readonly AppDbContext _context;

        public TemaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tema>> GetAll() => await _context.Temas.ToListAsync();
        public async Task<Tema?> GetById(long id) => await _context.Temas.FindAsync(id);
        public async Task Add(Tema tema) => await _context.Temas.AddAsync(tema);
        public void Update(Tema tema) => _context.Temas.Update(tema);
        public void Delete(Tema tema) => _context.Temas.Remove(tema);
        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}