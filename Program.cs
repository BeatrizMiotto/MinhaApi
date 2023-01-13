using MinhaApi.Models;
using MinhaApi.ModelViews;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PessoaFisicaRepositorio.Instancia().ListaFisica.Add(new PessoaFisica {Id = 1, Nome = "Jasmine", Telefone = "11987543265", Cpf = "32198785263", DataCriacao = "12/01/2023"});
PessoaFisicaRepositorio.Instancia().ListaFisica.Add(new PessoaFisica {Id = 2, Nome = "Eduardo", Telefone = "11987548745", Cpf = "63987415932", DataCriacao = "12/01/2023"});

app.Run();
