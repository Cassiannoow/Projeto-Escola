using Microsoft.AspNetCore.Mvc;
using Escola_API.Data;
using Escola_API.Models;

namespace Escola_API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [ActionName("CursoId")]
        [HttpGet("{CursoId}")]
        public ActionResult<Curso> Get(int cursoId)
        {
            try
            {
                var result = _context.Curso.Find(cursoId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao BD!");
            }
        }
        [HttpPost]
        public async Task<ActionResult> post(Curso model)
        {
            try
            {
                _context.Curso.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/Curso/{model.codCurso}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao BD!");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpDelete("{CursoId}")]
        public async Task<ActionResult> delete(int CursoId)
        {
            try
            {
                //verifica se existe Curso a ser excluído
                var Curso = await _context.Curso.FindAsync(CursoId);
                if (Curso == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(Curso);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao BD!");
            }
        }

        [HttpPut("{CursoId}")]
        public async Task<IActionResult> put(int cursoId, Curso dadosCursoAlt)
        {
            try
            {
                //verifica se existe Curso a ser alterado
                var result = await _context.Curso.FindAsync(cursoId);
                if (cursoId != result.id)
                {
                    return BadRequest();
                }
                result.codCurso = dadosCursoAlt.codCurso;
                result.nomeCurso = dadosCursoAlt.nomeCurso;
                result.periodo = dadosCursoAlt.periodo;
                await _context.SaveChangesAsync();
                return Created($"/api/Curso/{dadosCursoAlt.id}", dadosCursoAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Falha no acesso ao BD!");
            }
        }


        [ActionName("CursoNome")]
        [HttpGet("{CursoNome}")]
        public ActionResult<List<Curso>> GetCursoNome(string cursoNome)
        {

            if (_context.Curso is not null)
            {
                var result = _context.Curso.Where(a => a.nomeCurso == cursoNome);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            else
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
            "Falha no acesso ao banco de dados.");

            }

        }
    }
}