using Microsoft.AspNetCore.Mvc;
using Escola_API.Data;
using Escola_API.Models;

namespace Escola_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController: ControllerBase
    {
        private EscolaContext _context;
        public AlunoController(EscolaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Aluno>> GetAll()
        {
            return _context.Aluno.ToList();
        }
    }
}