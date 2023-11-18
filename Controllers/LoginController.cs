using AgendaOnline.Helper.Interface;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Caso usuario estiver logado
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario u = _usuarioRepositorio.BuscarPorLogin(login.NomeDeUsuario);

                    if (u != null && u.SenhaValidado(login.Senha))
                    {
                        _sessao.CriarSessaoDoUsuario(u);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MsgErro"] = $"Usuario ou senha podem estar incorretos. Por favor, tente novamente";
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel realizar seu login, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
