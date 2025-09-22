using ListaDesWeb.Models;

namespace ListaDesWeb.Repositories
{
    public interface IAlunoRepository
    {
        List<Aluno> ObterTodos();
        Aluno ObterPorRa(string ra);
        void Adicionar(Aluno aluno);
        void Atualizar(string ra, Aluno aluno);
        void Deletar(string ra);
    }
}