using MinhaApi.Models;

namespace MinhaApi.Repositorios.Interfaces;

public interface IServico
{
    Task<List<PessoaFisica>> TodosAsync();
    Task IncluirAsync(PessoaFisica pessoaFisica);
    Task<PessoaFisica> AtualizarAsync(PessoaFisica pessoaFisica);
    Task ApagarAsync(PessoaFisica pessoaFisica);
}