using BlogPessoal.Models;

namespace BlogPessoal.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByUsuario(string usuario);
        Task<Usuario?> GetById(long id);
        Task Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        Task SaveChanges();
    }
}