using JovemProgramadorWeb1.Data.Repositorio;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorWeb1.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;

        }
        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }

        public IActionResult Adicionar() 
        { 
            return View();
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
            if (ModelState.IsValid) // Verifica se o ModelState está válido
            {
                try
                {
                    _alunoRepositorio.InserirAluno(aluno);
                    TempData["MsgSucesso"] = "Aluno adicionado com sucesso";
                }
                catch (Exception e)
                {
                    TempData["MsgErro"] = "Erro ao inserir aluno: " + e.Message;
                }
            }
            else
            {
                // Se o ModelState não estiver válido, exibe mensagens de erro
                TempData["MsgErro"] = "Erro ao inserir aluno: Dados inválidos.";
            }

            return RedirectToAction("Index");
        }
        public IActionResult AtualizarAluno(Aluno aluno)
        {
            if (ModelState.IsValid) // Verifica se o ModelState está válido
            {
                try
                {
                    _alunoRepositorio.AtualizarAluno(aluno);
                    TempData["MsgSucesso"] = "Aluno atualizado com sucesso";
                }
                catch (Exception e)
                {
                    TempData["MsgErro"] = "Erro ao atualizar aluno: " + e.Message;
                }
            }
            else
            {
                // Se o ModelState não estiver válido, exibe mensagens de erro
                TempData["MsgErro"] = "Erro ao atualizar aluno: Dados inválidos.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverAluno(List<int> alunosSelecionados)
        {
            try
            {
                if (alunosSelecionados != null && alunosSelecionados.Any())
                {
                    foreach (int codigoAluno in alunosSelecionados)
                    {
                        var aluno = _alunoRepositorio.BuscarAlunos().FirstOrDefault(a => a.Codigo == codigoAluno);
                        if (aluno != null)
                        {
                            _alunoRepositorio.RemoverAluno(aluno);
                        }
                    }

                    TempData["MsgSucesso"] = "Alunos removidos com sucesso.";
                }
                else
                {
                    TempData["MsgErro"] = "Nenhum aluno foi selecionado para remoção.";
                }
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao remover alunos.";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"]+ cep + "/json");

                if(result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço!";
                }
            }
            catch (Exception) 
            {
                throw;
            }
            ViewData["MsgSucess"] = "Sucesso na busca do endereço!";
            return View("Endereco", endereco);
        }
    }
}