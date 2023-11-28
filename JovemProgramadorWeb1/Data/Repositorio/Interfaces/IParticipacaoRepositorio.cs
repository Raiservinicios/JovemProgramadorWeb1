using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IParticipacaoRepositorio
    {
        IEnumerable<Participacao> ObterParticipacaoEventos();
        string ObterNomeSocio(int codigoSocio);
        string ObterNomeEvento(int codigoEvento);
        void ExcluirParticipacao(int participacaoCodigo); // Exclui o evento do banco de dados

        // Adicione os demais métodos conforme necessário
    }
}
