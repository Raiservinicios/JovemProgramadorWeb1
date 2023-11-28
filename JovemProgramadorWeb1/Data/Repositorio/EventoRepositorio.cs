using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public EventoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public IEnumerable<Evento> ObterTodosEventos()
        {
            return _bancoContexto.Evento.ToList();
        }
    }
}
