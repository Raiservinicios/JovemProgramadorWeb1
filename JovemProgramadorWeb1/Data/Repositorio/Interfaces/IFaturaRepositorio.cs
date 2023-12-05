using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IFaturaRepositorio
    {
        IEnumerable <Fatura> ObterTodasFaturas();
        string ObterNomeSocio(int codigoSocio);
        Fatura ObterFatura(Fatura fatura);
    }
}
