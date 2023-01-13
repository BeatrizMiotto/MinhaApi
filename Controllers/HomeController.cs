using Microsoft.AspNetCore.Mvc;
using MinhaApi.ModelViews;

namespace MinhaApi.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [Route("/")]
    [HttpGet]
    public ActionResult Index()
    {
        return StatusCode(200, new Home{
            Mensagem = "Olá! Essa é minha Api!!!"
        });
    }
    
}