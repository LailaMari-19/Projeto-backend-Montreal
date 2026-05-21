using BlogPessoal.Models;

namespace BlogPessoal.Repositories
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Tema>> GetAll();
        Task<Tema?> GetById(long id);
        Task Add(Tema tema);
        void Update(Tema tema);
        void Delete(Tema tema);
        Task SaveChanges();
    }
}