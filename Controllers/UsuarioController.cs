using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        #region - Rotas
        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        #endregion

        #region - POST
        [HttpPost]
        public IActionResult Criar(Usuario u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    u = _usuarioRepositorio.Adicionar(u);
                    TempData["MsgSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(u);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel cadastrar o usuario, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}
