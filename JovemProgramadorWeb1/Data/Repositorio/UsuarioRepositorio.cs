using System.Linq;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Data;
using JovemProgramadorWeb1.Models;

namespace JovemProgramadorWeb1.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public UsuarioRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public Usuario ValidarUsuario(Usuario usuario)
        {
            return _bancoContexto.Usuario.FirstOrDefault(x => x.nomeUsuario == usuario.nomeUsuario && x.senha == usuario.senha);
        }
    }
}
