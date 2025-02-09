using Business.Interfaces.User;
using Business.Services.User;
using Data.Context;
using Data.Interfaces.User;
using Data.Repository.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de Dependência
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Adiciona suporte a controllers
builder.Services.AddControllers(); // 🔹 ESSENCIAL PARA EVITAR O ERRO

// Adiciona autenticação e autorização
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(); // (Opcional, caso queira autenticação futura)

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FocusStep",
        Version = "v1",
        Description = "API para o aplicativo mobile"
    });
});

var app = builder.Build();

// Configuração do Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "FocusStep v1");
        options.RoutePrefix = string.Empty; // Swagger será carregado na raiz
    });
}

app.UseHttpsRedirection();

// Adiciona autenticação e autorização no pipeline
app.UseAuthorization();

app.MapControllers(); // 🔹 ESSENCIAL PARA OS CONTROLLERS FUNCIONAREM

app.Run();
