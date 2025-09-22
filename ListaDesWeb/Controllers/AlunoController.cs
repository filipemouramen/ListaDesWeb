using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListaDesWeb.Models;
using ListaDesWeb.Repositories;

namespace ListaDesWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
      private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Aluno>> ObterTodos()
        {
            var alunos = _alunoRepository.ObterTodos();
            return Ok(alunos);
        }

        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _alunoRepository.Adicionar(aluno);
            return Ok("Aluno adicionado com sucesso!");
        }

        [HttpPut]
        [Route("Atualizar/{ra}")]
        public ActionResult Atualizar(string ra, [FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _alunoRepository.Atualizar(ra, aluno);
            return Ok("Aluno atualizado com sucesso!");
        }

    }
}