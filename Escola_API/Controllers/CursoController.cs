using Microsoft.AspNetCore.Mvc;
using Escola_API.Data;
using Escola_API.Models;

namespace Escola_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController: ControllerBase
    {
        private EscolaContext _context;
        public CursoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Curso>> GetAll()
        {
            return _context.Curso.ToList();
        }
    }
}