using BlogPessoal.DTOs; // Adicione esta linha no topo
using BlogPessoal.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("logar")]
    public async Task<IActionResult> Logar([FromBody] UsuarioLoginDTO userLogin)
    {
        var user = await _authService.Autenticar(userLogin.Usuario, userLogin.Senha);
        if (user == null) return Unauthorized("Usuário ou senha inválidos.");

        var token = _authService.GerarToken(user);
        return Ok(new { token = token });
    }
}