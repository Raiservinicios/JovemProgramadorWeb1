using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Participacao> ObterParticipacaoEventos(int codigo)
        {
            return _bancoContexto.Participacao.Where(p => p.codigoSocio == codigo).ToList();
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

        public bool ExcluirParticipacao(int participacaoCodigo)
        {
            var participacao = _bancoContexto.Participacao.Find(participacaoCodigo);

            if (participacao != null)
            {
                _bancoContexto.Participacao.Remove(participacao);
                _bancoContexto.SaveChanges();

                return true;
            }
            return false;
        }
        public bool AdicionarParticipacao(int eventoCodigo, int codigoSocio)
        {
            DateTime dataHoraAtual = DateTime.Now;

            var participacaoExistente = _bancoContexto.Participacao
                .FirstOrDefault(p => p.codigoEvento == eventoCodigo && p.codigoSocio == codigoSocio);

            if (participacaoExistente != null)
            {
                // Se o sócio já estiver participando, você pode exibir uma mensagem ou tomar outra ação.
                // Neste exemplo, estamos apenas retornando false.
                return false;
            }

            var evento = _bancoContexto.Evento.FirstOrDefault(e => e.codigo == eventoCodigo);

            if (evento != null)
            {
                var participacao = new Participacao
                {
                    codigoEvento = eventoCodigo,
                    codigoSocio = codigoSocio,
                    dataHoraConfirmacao = dataHoraAtual,
                };

                _bancoContexto.Participacao.Add(participacao);

                _bancoContexto.SaveChanges();

                return true;
            }

            return false;
        }

    }
}



