using MinhaApi.Models;

namespace MinhaApi.ModelViews;

public class PessoaFisicaRepositorio
{
    private PessoaFisicaRepositorio()
    {
        ListaFisica = new List<PessoaFisica>();
    }
    public  List<PessoaFisica> ListaFisica = default!;

    private static PessoaFisicaRepositorio? pessoaFisicaRepositorio;

    public static PessoaFisicaRepositorio Instancia()
    {
        if(pessoaFisicaRepositorio is null) pessoaFisicaRepositorio = new PessoaFisicaRepositorio();
        return pessoaFisicaRepositorio;
    }
    
}