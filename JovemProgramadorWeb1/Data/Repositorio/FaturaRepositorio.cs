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

        public Fatura ObterFatura(Fatura fatura)
        {
            return _bancoContexto.Fatura.FirstOrDefault(x => x.codigoSocio == fatura.codigoSocio && x.mesAnoFatura == fatura.mesAnoFatura);
        }

        public string ObterNomeSocio(int codigoSocio)
        {
            var socio = _bancoContexto.Socio.FirstOrDefault(s => s.codigo == codigoSocio);
            return socio != null ? socio.nomeCompleto : "Sócio não encontrado";
        }
    }
}
