using MySoftwareSkills.Application.Interfaces;
using MySoftwareSkills.Application.Services;
using MySoftwareSkills.Domain.Interfaces;
using MySoftwareSkills.Infrastructure.Data;
using MySoftwareSkills.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurações do MongoDB
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Injeção de Dependência para o Contexto do MongoDB
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();

// Injeção de Dependência para Repositórios e Serviços
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();

// Adiciona os serviços necessários para o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona serviços MVC e controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configura o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MySoftwareSkills API V1");
        c.RoutePrefix = string.Empty; // Define o Swagger como a página inicial
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
