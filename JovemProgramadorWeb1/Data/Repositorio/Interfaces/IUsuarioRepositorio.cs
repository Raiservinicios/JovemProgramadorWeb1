using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public Usuario ValidarUsuario(Usuario usuario);

        public Socio BuscarDadosSocio (Usuario usuario);
    }
}
