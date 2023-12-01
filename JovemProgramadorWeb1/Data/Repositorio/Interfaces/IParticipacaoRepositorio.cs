using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IParticipacaoRepositorio
    {
        List<Participacao> ObterParticipacaoEventos(int codigo);
        string ObterNomeSocio(int codigoSocio);
        string ObterNomeEvento(int codigoEvento);
        bool ExcluirParticipacao(int participacaoCodigo);
        bool AdicionarParticipacao(int eventoCodigo, int codigoSocio);

    }
}
