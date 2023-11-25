using AgendaOnline.Filters;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    [PagParaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;
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

        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            List<Contato> contatos = _contatoRepositorio.BuscarTodos(id);
            return PartialView("_ContatosUsuario", contatos);
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
