using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public void InserirAluno(Aluno aluno) 
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        public void RemoverAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
        public void AtualizarAluno(Aluno aluno)
        {
            _bancoContexto.Update(aluno);
            _bancoContexto.SaveChanges();
        }
        public Aluno BuscarAlunoPorCodigo(int codigo)
        {
            return _bancoContexto.Set<Aluno>().FirstOrDefault(a => a.Codigo == codigo);
        }
    }
}
