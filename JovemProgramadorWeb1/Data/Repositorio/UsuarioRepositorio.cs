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

        public Usuario ValidarResposta(Usuario usuario)
        {
            return _bancoContexto.Usuario.FirstOrDefault(x => x.nomeUsuario == usuario.nomeUsuario && x.respostaSeguranca == usuario.respostaSeguranca);
        }
        public Usuario BuscarFlagStatus(Usuario usuario)
        {
            return _bancoContexto.Usuario.FirstOrDefault(x => x.codigo == usuario.codigo);
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
        public void AtualizarSenha(Usuario usuario)
        {
            // Lógica para atualizar a senha no banco de dados
            // Certifique-se de implementar essa lógica de acordo com a sua estrutura de dados
            var usuarioNoBanco = _bancoContexto.Usuario.FirstOrDefault(u => u.codigo == usuario.codigo);

            if (usuarioNoBanco != null)
            {
                usuarioNoBanco.senha = usuario.senha;

                // Salvar as alterações no banco de dados
                _bancoContexto.SaveChanges();
            }
        }
    }
}
