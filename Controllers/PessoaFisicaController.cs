using Microsoft.AspNetCore.Mvc;
using MinhaApi.ModelViews;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[Route("PessoaFisica")]
public class PessoaFisicaController : ControllerBase
{
    //Mostra na tela
    [HttpGet("")]
    public IActionResult Index()
    {
        var pFisica = PessoaFisicaRepositorio.Instancia().ListaFisica;
        return StatusCode(200,  pFisica);
    }

    //Busca Por ID
    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var pf = PessoaFisicaRepositorio.Instancia().ListaFisica.Find(c => c.Id == id);

        return StatusCode(200, pf);
    }
    //Cadastra
    [HttpPost("")]
    public IActionResult Create([FromBody] PessoaFisica pessoaFisica)
    {
        PessoaFisicaRepositorio.Instancia().ListaFisica.Add(pessoaFisica);
        return StatusCode(201, pessoaFisica);
    }

    //Editar por id
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] PessoaFisica pessoaFisica)
    {
        if (id != pessoaFisica.Id)
        {
            return StatusCode(400, new {
                Mensagem = "Erro"
            });
        }

       var pessoaFisicaDb = PessoaFisicaRepositorio.Instancia().ListaFisica.Find(c => c.Id == id);
       if(pessoaFisicaDb is null)
       {
            return StatusCode(404, new {
                Mensagem = "O Pessoa não existe"
            });
        }

        pessoaFisicaDb.Nome = pessoaFisica.Nome;
        pessoaFisicaDb.Telefone =pessoaFisica.Telefone;
        pessoaFisicaDb.Cpf =pessoaFisica.Cpf;
        pessoaFisicaDb.DataCriacao =pessoaFisica.DataCriacao;

        return StatusCode(200, pessoaFisicaDb);
    }

    //Deletar ID
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var pessoaFisicaDb = PessoaFisicaRepositorio.Instancia().ListaFisica.Find(c => c.Id == id);
        if(pessoaFisicaDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O pessoa não existe"
            });
        }

        PessoaFisicaRepositorio.Instancia().ListaFisica.Remove(pessoaFisicaDb);

        return RedirectToAction(nameof(Index));
    }
}