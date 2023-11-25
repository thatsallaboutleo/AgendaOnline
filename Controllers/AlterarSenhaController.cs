using AgendaOnline.Helper.Interface;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenha alterarSenha)
        {
            try
            {
                Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Id = usuarioLogado.Id;
                
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenha);
                    TempData["MsgSucesso"] = "Senha alterada com sucesso";
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel alterar sua senha, erro: {e.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
