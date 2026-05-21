using Microsoft.EntityFrameworkCore;
using BlogPessoal.Data;
using BlogPessoal.Repositories;
using BlogPessoal.Services;
using BlogPessoal.Services.IA;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. Registro de Repositórios (Injeção de Dependência)
builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// 3. Registro de Serviços (Auth e IA)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IIAService, OpenAIService>();

// 4. Configurações de API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Middlewares
app.UseHttpsRedirection();

// Comente ou remova o UseAuthorization() temporariamente caso o erro de 
// "AuthenticationScheme" persista até você configurar o JWT no builder.Services.
// app.UseAuthorization(); 

app.MapControllers();

app.Run();