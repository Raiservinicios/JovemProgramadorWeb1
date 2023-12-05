using JovemProgramadorWeb1.Data;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class CadastrarDependentesController : Controller
    {
        [HttpGet]
        public IActionResult CadastrarDependentesIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarDependentesIndex(Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                // Aqui você pode adicionar lógica para salvar o dependente no banco de dados
                // dependenteViewModel conterá os dados do formulário submetido

                // Exemplo com o Entity Framework:
                var dependente = new Dependente
                {
                    nomeCompleto = dependente.NomeCompleto,
                    cpf = dependente.CPF,
                    dataNascimento = dependente.DataNascimento,
                    parentesco = dependente.Parentesco,
                    usuario = dependente.Usuario,
                    senha = dependente.Senha
                };

                _bancoContexto.Dependente.Add(dependente);
                _bancoContexto.SaveChanges();

                // Talvez você queira redirecionar para outra página ou recarregar a página atual
                return RedirectToAction("CadastrarDependentesIndex");
            }

            // Se a validação falhar, você pode querer lidar com isso de acordo com seus requisitos
            return View(dependente);
        }
    }
}
