using ListaDesWeb.Models;
using ListaDesWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDesWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Produto>> ObterTodos()
        {
            var produtos = _produtoRepository.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("ObterPorCodigo/{codigo}")]
        public ActionResult<Produto> ObterPorCodigo(string codigo)
        {
            var produto = _produtoRepository.ObterPorCodigo(codigo);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Adicionar([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoRepository.Adicionar(produto);
            return Ok("Produto adicionado com sucesso!");
        }

        [HttpPut]
        [Route("Atualizar/{codigo}")]
        public ActionResult Atualizar(string codigo, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoRepository.Atualizar(codigo, produto);
            return Ok("Produto atualizado com sucesso!");
        }

        [HttpDelete]
        [Route("Deletar/{codigo}")]
        public ActionResult Deletar(string codigo)
        {
            _produtoRepository.Deletar(codigo);
            return Ok("Produto deletado com sucesso!");
        }
    }
}