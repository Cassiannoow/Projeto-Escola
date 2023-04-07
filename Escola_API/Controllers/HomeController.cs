using Microsoft.AspNetCore.Mvc;

namespace Escola_API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController
    {
        [HttpGet]
        public ActionResult Inicio()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<h1>API Projeto Escola: Funcionou!!!!</h1>" 
            };
        }
    }
}