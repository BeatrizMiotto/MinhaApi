using MinhaApi.Models;

namespace MinhaApi.ModelViews;

public class OrcamentoRepositorio
{
    private OrcamentoRepositorio()
    {
        ListaOrcamento = new List<Orcamento>();
    }
    public  List<Orcamento> ListaOrcamento = default!;

    private static OrcamentoRepositorio? orcamentoRepositorio;

    public static OrcamentoRepositorio Instancia()
    {
        if(orcamentoRepositorio is null) orcamentoRepositorio = new OrcamentoRepositorio();
        return orcamentoRepositorio;
    }
    
}