using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface ICadastrarRepositorio
    {
        void InserirDependente(Dependente dependente, int codigoUsuario);
    }
}