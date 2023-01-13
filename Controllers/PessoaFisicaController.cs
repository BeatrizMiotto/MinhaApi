using Microsoft.AspNetCore.Mvc;
using MinhaApi.ModelViews;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[Route("PessoaFisica")]
public class PessoaFisicaController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var pFisica = PessoaFisicaRepositorio.Instancia().ListaFisica;
        return StatusCode(200,  pFisica);
    }
}