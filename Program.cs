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

PessoaJuridicaRepositorio.Instancia().ListaJuridica.Add(new PessoaJuridica {Id = 1, Nome = "Jasmine Artesanato LTDA", Telefone = "119854265871", Cnpj = "98765432195874", DataCriacao = "13/01/2023"});
PessoaJuridicaRepositorio.Instancia().ListaJuridica.Add(new PessoaJuridica {Id = 2, Nome = "DU Motos LTDA", Telefone = "119653278457", Cnpj = "23659874561236", DataCriacao = "13/01/2023"});

OrcamentoRepositorio.Instancia().ListaOrcamento.Add(new Orcamento {Id = 1, ClienteId = 1, FornecedorId = 2, DescricaoDoServico = "Venda de uma moto Honda", ValorTotal = 1500, DataCriacao = "13/01/2023", DataExpiracao = "13/01/2024"});
OrcamentoRepositorio.Instancia().ListaOrcamento.Add(new Orcamento {Id = 2, ClienteId = 2, FornecedorId = 1, DescricaoDoServico = "Venda de Tapetes feito a mão", ValorTotal = 3000, DataCriacao = "13/01/2023", DataExpiracao = "13/01/2025"});

app.Run();
