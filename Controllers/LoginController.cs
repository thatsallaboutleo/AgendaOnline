using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
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
