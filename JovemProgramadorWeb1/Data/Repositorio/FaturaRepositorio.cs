using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class FaturaRepositorio : IFaturaRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public FaturaRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public IEnumerable<Fatura> ObterTodasFaturas()
        {
            return _bancoContexto.Fatura.ToList();
        }
    }
}
