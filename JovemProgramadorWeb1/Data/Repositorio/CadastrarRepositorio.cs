using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class CadastrarRepositorio : ICadastrarRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public CadastrarRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public void InserirDependente(Dependente dependente, int codigoUsuario)
        {
            _bancoContexto.Dependentes.Add(dependente);
            _bancoContexto.SaveChanges();
        }
    }
}
