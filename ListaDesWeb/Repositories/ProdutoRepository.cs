using ListaDesWeb.Models;

namespace ListaDesWeb.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> ObterTodos();
        Produto ObterPorCodigo(string codigoProduto);
        void Adicionar(Produto produto);
        void Atualizar(string codigoProduto, Produto produto);
        void Deletar(string codigoProduto);
    }
}