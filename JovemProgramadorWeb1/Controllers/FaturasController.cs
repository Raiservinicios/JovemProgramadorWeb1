using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class FaturasController : Controller
    {
        private readonly IFaturaRepositorio _faturaRepositorio;

        public FaturasController(IFaturaRepositorio faturaRepositorio)
        {
            _faturaRepositorio = faturaRepositorio;
        }
        public IActionResult FaturasIndex()
        {
            var listaDeFaturas = _faturaRepositorio.ObterTodasFaturas();
            return View(listaDeFaturas);
        }

        public IActionResult ValidarFatura(Fatura fatura, int codigoSocio, string mesAnoFatura) 
        {
            fatura.codigoSocio = codigoSocio;
            fatura.mesAnoFatura = mesAnoFatura;
            fatura = _faturaRepositorio.ObterFatura(fatura);

            var faturaAnterior = fatura;
            faturaAnterior.codigo = (faturaAnterior.codigo - 1);

            faturaAnterior = _faturaRepositorio.ObterFatura(faturaAnterior);

            if(faturaAnterior.flagPagamento == true)
            {
                TempData["msgErro"] = "A fatura do mês anterior ainda não foi paga";
                return RedirectToAction("FaturasIndex");
            }
            else
            {
                TempData["msgSucesso"] = "Pronto para pagar";
                return RedirectToAction("FaturasIndex");
            }
        }
    }
}
