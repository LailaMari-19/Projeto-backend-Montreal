using BlogPessoal.Data;
using BlogPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByUsuario(string usuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioEmail == usuario);
        }

        public async Task<Usuario?> GetById(long id) => await _context.Usuarios.FindAsync(id);

        public async Task Add(Usuario usuario) => await _context.Usuarios.AddAsync(usuario);

        public void Update(Usuario usuario) => _context.Usuarios.Update(usuario);

        public void Delete(Usuario usuario) => _context.Usuarios.Remove(usuario);

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}