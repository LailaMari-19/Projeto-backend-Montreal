using BlogPessoal.Models;

namespace BlogPessoal.Repositories
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> GetAll();
        Task<Postagem?> GetById(long id);
        Task Add(Postagem postagem);
        void Update(Postagem postagem);
        void Delete(Postagem postagem);
        Task SaveChanges();
    }
}