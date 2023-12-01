using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class ParticipacaoController : Controller
    {
        private readonly IParticipacaoRepositorio _participacaoRepositorio;

        public ParticipacaoController(IParticipacaoRepositorio participacaoRepositorio)
        {
            _participacaoRepositorio = participacaoRepositorio;
        }

        public IActionResult ParticipacaoIndex(int codigo)
        {
            var participacao = _participacaoRepositorio.ObterParticipacaoEventos(codigo);
            return View(participacao);
        }
        public IActionResult ExcluirParticipacao(int codigoEvento,int codigoSocio)
        {
            var participacaoCodigo = codigoEvento;
            var excluirParticipacao = _participacaoRepositorio.ExcluirParticipacao(participacaoCodigo);

            if (excluirParticipacao)
            {
                TempData["SucessoExcluir"] = "Participação excluída com sucesso.";
            }
            else
            {
                TempData["ErroExcluir"] = "Erro ao excluir a participação.";
            }

            return RedirectToAction("ParticipacaoIndex", new { codigo = codigoSocio });
        }
        public IActionResult AdicionarParticipacao(int codigoEvento, int codigoSocio)
        {
            var eventoCodigo = codigoEvento;
            var adicionarParticipacao = _participacaoRepositorio.AdicionarParticipacao(eventoCodigo,codigoSocio);

            if (adicionarParticipacao)
            {
                TempData["MensagemSucesso"] = "Participação adicionada com sucesso.";
            }
            else
            {
                TempData["Mensagemfalha"] = "Já está participando.";
            }

            return RedirectToAction("EventosIndex","Eventos", new { codigo = codigoSocio });
        }
    }
}


