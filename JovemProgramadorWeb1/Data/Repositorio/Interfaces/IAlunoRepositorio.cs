using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Aluno BuscarAlunoPorCodigo(int codigo);
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);

        void RemoverAluno(Aluno aluno);

        void AtualizarAluno(Aluno aluno);
    }
}
