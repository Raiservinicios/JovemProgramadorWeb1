using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using System.Collections.Generic;
using System.Linq;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class ParticipacaoRepositorio : IParticipacaoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public ParticipacaoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public IEnumerable<Participacao> ObterParticipacaoEventos()
        {
            return _bancoContexto.Participacao.ToList();
        }

        public string ObterNomeSocio(int codigoSocio)
        {
            var socio = _bancoContexto.Socio.FirstOrDefault(s => s.codigo == codigoSocio);
            return socio != null ? socio.nomeCompleto : "Sócio não encontrado";
        }

        public string ObterNomeEvento(int codigoEvento)
        {
            var evento = _bancoContexto.Evento.FirstOrDefault(e => e.codigo == codigoEvento);
            return evento != null ? evento.nomeEvento : "Evento não encontrado";
        }

        public void ExcluirParticipacao(int participacaoCodigo)
        {
            var participacao = _bancoContexto.Participacao.Find(participacaoCodigo);

            if (participacao != null)
            {
                _bancoContexto.Participacao.Remove(participacao);
                _bancoContexto.SaveChanges();
            }
        }
    }
}



