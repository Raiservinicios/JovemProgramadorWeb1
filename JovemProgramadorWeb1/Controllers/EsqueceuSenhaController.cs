﻿using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb1.Controllers
{
    public class EsqueceuSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public EsqueceuSenhaController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public IActionResult EsqueceuSenhaIndex()
        {
            return View();
        }

        [HttpPost]

        [HttpPost]
        public IActionResult AlterarSenha(string nomeUsuario, string respostaSeguranca, string novaSenha)
        {
            Usuario usuario = new Usuario
            {
                nomeUsuario = nomeUsuario,
                respostaSeguranca = respostaSeguranca,
                senha = novaSenha
            };

            var usuarioValidado = _usuarioRepositorio.ValidarResposta(usuario);

            if (usuarioValidado != null && VerificarRespostaSeguranca(usuarioValidado, respostaSeguranca))
            {
                usuarioValidado.senha = novaSenha;
                _usuarioRepositorio.AtualizarSenha(usuarioValidado);
                TempData["MsgSucesso"] = "Senha alterada com sucesso!";
                return RedirectToAction("Index", "Login", TempData["MsgSucesso"]);
            }
            else
            {
                TempData["MsgErro"] = "Usuário não encontrado, verifique se os dados estão preenchidos corretamente!";
                return RedirectToAction("EsqueceuSenhaIndex");
            }
        }
        public IActionResult Index()
        {

            return View();
        }

        private bool VerificarRespostaSeguranca(Usuario usuario, string respostaSeguranca)
        {

            if (usuario != null && !string.IsNullOrEmpty(usuario.respostaSeguranca))
            {

                return string.Equals(usuario.respostaSeguranca, respostaSeguranca, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}