using Microsoft.AspNetCore.Mvc;
using MinhaApi.ModelViews;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[Route("PessoaJuridica")]
public class PessoaJuridicaController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var pJuridica = PessoaJuridicaRepositorio.Instancia().ListaJuridica;
        return StatusCode(200,  pJuridica);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var pj = PessoaJuridicaRepositorio.Instancia().ListaJuridica.Find(c => c.Id == id);

        return StatusCode(200, pj);
    }

    [HttpPost("")]
    public IActionResult Create([FromBody] PessoaJuridica pessoaJuridica)
    {
        PessoaJuridicaRepositorio.Instancia().ListaJuridica.Add(pessoaJuridica);
        return StatusCode(201, pessoaJuridica);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] PessoaJuridica pessoaJuridica)
    {
        if (id != pessoaJuridica.Id)
        {
            return StatusCode(400, new {
                Mensagem = "Erro"
            });
        }

       var pessoaJuridicaDb = PessoaJuridicaRepositorio.Instancia().ListaJuridica.Find(c => c.Id == id);
       if(pessoaJuridicaDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O empresa não existe"
            });
        }

        pessoaJuridicaDb.Nome = pessoaJuridica.Nome;
        pessoaJuridicaDb.Telefone =pessoaJuridica.Telefone;
        pessoaJuridicaDb.Cnpj =pessoaJuridica.Cnpj;
        pessoaJuridicaDb.DataCriacao =pessoaJuridica.DataCriacao;

        return StatusCode(200, pessoaJuridicaDb);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var pessoaJuridicaDb = PessoaJuridicaRepositorio.Instancia().ListaJuridica.Find(c => c.Id == id);
        if(pessoaJuridicaDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O pessoa não existe"
            });
        }

        PessoaJuridicaRepositorio.Instancia().ListaJuridica.Remove(pessoaJuridicaDb);

        return RedirectToAction(nameof(Index));
    }

}