using Microsoft.AspNetCore.Mvc;
using MinhaApi.ModelViews;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[Route("Orcamento")]
public class OrcamentoController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var orcamentos = OrcamentoRepositorio.Instancia().ListaOrcamento;
        return StatusCode(200,  orcamentos);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var orcamento = OrcamentoRepositorio.Instancia().ListaOrcamento.Find(c => c.Id == id);

        return StatusCode(200, orcamento);
    }

    [HttpPost("")]
    public IActionResult Create([FromBody] Orcamento orcamento)
    {
        OrcamentoRepositorio.Instancia().ListaOrcamento.Add(orcamento);
        return StatusCode(201, orcamento);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Orcamento orcamento)
    {
        if (id != orcamento.Id)
        {
            return StatusCode(400, new {
                Mensagem = "Erro"
            });
        }

       var orcamentoDb = OrcamentoRepositorio.Instancia().ListaOrcamento.Find(c => c.Id == id);
       if(orcamentoDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O empresa não existe"
            });
        }

        orcamentoDb.ClienteId = orcamento.ClienteId;
        orcamentoDb.FornecedorId =orcamento.FornecedorId;
        orcamentoDb.DescricaoDoServico =orcamento.DescricaoDoServico;
        orcamentoDb.ValorTotal =orcamento.ValorTotal;
        orcamentoDb.DataCriacao =orcamento.DataCriacao;
        orcamentoDb.DataExpiracao =orcamento.DataExpiracao;

        return StatusCode(200, orcamentoDb);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var orcamentoDb = OrcamentoRepositorio.Instancia().ListaOrcamento.Find(c => c.Id == id);
        if(orcamentoDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O orçamento não localizado ou não existe"
            });
        }

        OrcamentoRepositorio.Instancia().ListaOrcamento.Remove(orcamentoDb);

        return RedirectToAction(nameof(Index));
    }

}