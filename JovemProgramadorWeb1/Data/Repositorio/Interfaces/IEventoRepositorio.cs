using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IEventoRepositorio
    {
        // Obtém a lista dos eventos do banco
        IEnumerable<Evento> ObterTodosEventos();

        //Evento ObterEventoPorCodigo(int eventoCodigo); / Obtém um evento pelo Codigo

        //void AdicionarEvento(Evento evento); // Salva um novo evento no banco de dados

        //void AtualizarEvento(Evento evento); // Atualiza as informações do evento no banco de dados

        //void ExcluirEvento(int eventoId); // Exclui o evento do banco de dados
    }
}
