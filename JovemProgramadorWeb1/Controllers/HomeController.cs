using JovemProgramadorWeb1.Data.Repositorio;
using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;


namespace JovemProgramadorWeb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepositorio usuarioRepositorio)
        {
            _logger = logger;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index(Usuario usuario, Socio socio)
        {

            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ExternalLink()
        {
            string externalUrl = "https://www.linkedin.com/in/viniciosraiser/";
            return Redirect(externalUrl);
        }
		[HttpPost]
		public ActionResult BuscarUsuario(string nomeUsuario, string senha)
		{
			// Conecte-se ao banco de dados SQL Server
			string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DesenvolvimentoWeb;MultipleActiveResultSets=true; TrustServerCertificate=True; Data Source=VINICIOSRAISER\\SQLEXPRESS"; //STRING CASA;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Execute a consulta SQL para buscar o usuário com base no nome de usuário e senha
				string query = "SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario AND Senha = @Senha";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
				command.Parameters.AddWithValue("@Senha", senha);

				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					// O usuário foi encontrado, você pode redirecioná-lo para outra página ou fazer o que for necessário
					return RedirectToAction("UsuarioEncontrado");
				}
                else
                {
                    // O usuário não foi encontrado, exiba um modal de erro com uma mensagem personalizada
                    ViewBag.ErrorMessage = "Usuário ou senha incorretos.";
                    return RedirectToAction("UsuarioNaoEncontrado");
                }
            }
        }
		public ActionResult UsuarioEncontrado()
		{
			return View("Index");
		}
        public ActionResult UsuarioNaoEncontrado()
        {
            return View("IndexErro");
        }
    }
}
