using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.DTOs;
using MinhaApi.Models;
using MinhaApi.Repositorios.Interfaces;
using MinhaApi.Servicos;

namespace MinhaApi.Controllers;

[Route("pessoaFisica")]
public class PessoaFisicaController : ControllerBase
{
    private IServico _servico;
    public PessoaFisicaController(IServico servico)
    {
        _servico = servico;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var pessoaFisica = await _servico.TodosAsync();
        return StatusCode(200, pessoaFisica);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
       var pessoaFisica = (await _servico.TodosAsync()).Find(c => c.Id == id);

        return StatusCode(200, pessoaFisica);
    }

    
   
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] PessoaFisicaDTO pessoaFisicaDTO)
    {
        var pessoaFisica = BuilderServico<PessoaFisica>.Builder(pessoaFisicaDTO);
        await _servico.IncluirAsync(pessoaFisica);
        return StatusCode(201, pessoaFisica);
    }


   
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PessoaFisica pessoaFisica)
    {
        if (id != pessoaFisica.Id)
        {
            return StatusCode(400, new {
                Mensagem = "O Id do PF precisa bater com o id da URL"
            });
        }

        var pessoaFisicaDb = await _servico.AtualizarAsync(pessoaFisica);

        return StatusCode(200, pessoaFisicaDb);
    }

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var pessoaFisicaDb = (await _servico.TodosAsync()).Find(c => c.Id == id);
        if(pessoaFisicaDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "A informação não é valida"
            });
        }

        await _servico.ApagarAsync(pessoaFisicaDb);

        return StatusCode(204);
    }
}