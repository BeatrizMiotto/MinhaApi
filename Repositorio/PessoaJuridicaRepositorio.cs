using MinhaApi.Models;

namespace MinhaApi.ModelViews;

public class PessoaJuridicaRepositorio
{
    private PessoaJuridicaRepositorio()
    {
        ListaJuridica = new List<PessoaJuridica>();
    }
    public  List<PessoaJuridica> ListaJuridica = default!;

    private static PessoaJuridicaRepositorio? pessoaJuridicaRepositorio;

    public static PessoaJuridicaRepositorio Instancia()
    {
        if(pessoaJuridicaRepositorio is null) pessoaJuridicaRepositorio = new PessoaJuridicaRepositorio();
        return pessoaJuridicaRepositorio;
    }
    
}