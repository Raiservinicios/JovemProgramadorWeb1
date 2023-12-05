using JovemProgramadorWeb1.Data;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class CadastrarDependentesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICadastrarRepositorio _cadastrarRepositorio;

        [HttpGet]
        public IActionResult CadastrarDependentesIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarDependente(Dependente dependente, int codigoUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cadastrarRepositorio.InserirDependente(dependente, codigoUsuario);
                    TempData["MsgSucesso"] = "Dependente cadastrado com sucesso";
                }
                catch (Exception e)
                {
                    TempData["MsgErro"] = "Erro ao cadastrar dependente: " + e.Message;
                }
            }
            else
            {
                TempData["MsgErro"] = "Erro ao cadastrar dependente: Dados inválidos.";
            }

            return RedirectToAction("Index");
        }

    }
}
