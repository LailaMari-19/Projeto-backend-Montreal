using BlogPessoal.Models;

namespace BlogPessoal.Services
{
    public interface IAuthService
    {
        Task<Usuario?> Autenticar(string usuario, string senha);
        string GerarToken(Usuario usuario);
    }
}