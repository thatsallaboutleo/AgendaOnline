using AgendaOnline.Models;
using AgendaOnline.Repositorio;
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

        public IActionResult Editar(int id)
        {
            Usuario u = _usuarioRepositorio.BuscarId(id);
            return View(u);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            Usuario u = _usuarioRepositorio.BuscarId(id);
            return View(u);
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

        #region - PUT
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenha usuarioSemSenha)
        {
            try
            {
                Usuario usuario = null;
                
                if (ModelState.IsValid)
                {
                    usuario = new Usuario()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MsgSucesso"] = "Usuario atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel atualizar o usuario, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region - DELETE
        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagou = _usuarioRepositorio.Apagar(id);
                if (apagou)
                {
                    TempData["MsgSucesso"] = "Usuario deletado com sucesso";
                }
                else
                {
                    TempData["MsgErro"] = "Não foi possivel deletar o usuario";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel deletar o usuario, erro: {e.Message}";
                return RedirectToAction("Index"); ;
            }
        }
        #endregion
    }
}
