using MinhaApi.Models;
using MinhaApi.Repositorios.Interfaces;

namespace MinhaApi.ModelViews;

public class PessoaFisicaRepositorio : IServico
{
    private static List<PessoaFisica> lista = new List<PessoaFisica>();

    public async Task<List<PessoaFisica>> TodosAsync()
    {
        return await Task.FromResult(lista);
    }

    public async Task IncluirAsync(PessoaFisica pessoaFisica)
    {
        lista.Add(pessoaFisica);    
        await Task.FromResult(new {});
    }

    public async Task<PessoaFisica> AtualizarAsync(PessoaFisica pessoaFisica)
    {
        if(pessoaFisica.Id == 0) throw new Exception("Id não pode ser zero");

        var pessoaFisicaDb = lista.Find(c => c.Id == pessoaFisica.Id);
        if(pessoaFisicaDb is null)
        {
            throw new Exception("O cliente informado não existe");
        }

        pessoaFisicaDb.Nome = pessoaFisica.Nome;
        pessoaFisicaDb.Telefone = pessoaFisica.Telefone;
        pessoaFisicaDb.Cpf = pessoaFisica.Cpf;
        pessoaFisicaDb.DataCriacao = pessoaFisica.DataCriacao;
        return await Task.FromResult(pessoaFisicaDb);
    }

    public async Task ApagarAsync(PessoaFisica pessoaFisica)
    {
        lista.Remove(pessoaFisica);
        await Task.FromResult(new {});
    }
}