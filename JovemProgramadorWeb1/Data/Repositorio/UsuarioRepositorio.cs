using System.Linq;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Data;
using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore;

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

        public Socio BuscarDadosSocio(Usuario usuario) {
            Socio socio = new Socio();
            socio.codigoUsuario = usuario.codigo;

            return  _bancoContexto.Socio.Find(socio.codigoUsuario);
        }
        public Socio ObterSocioPorCodigoUsuario(int codigoUsuario)
        {
            // Lógica para obter informações do sócio pelo código do usuário
            return _bancoContexto.Socio.FirstOrDefault(s => s.codigoUsuario == codigoUsuario);
        }
    }
}
