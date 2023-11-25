using AgendaOnline.Filters;
using AgendaOnline.Helper.Interface;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    [PagUsuarioLogado]
    public class ContatoController : Controller
    {
        #region - Contrutor
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }
        #endregion

        #region - GET
        public IActionResult Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            var contatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagou = _contatoRepositorio.Apagar(id);
                if (apagou)
                {
                    TempData["MsgSucesso"] = "Contato deletado com sucesso";
                }
                else
                {
                    TempData["MsgErro"] = "Não foi possivel deletar o contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel deletar o contato, erro: {e.Message}";
                return RedirectToAction("Index"); ;
            }
        }
        #endregion

        #region - POST
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MsgSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel cadastrar o contato, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Alterar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contato.UsuarioId = usuarioLogado.Id;

                    contato = _contatoRepositorio.Atualizar(contato);
                    TempData["MsgSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel atualizar o contato, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region - PUT
        public IActionResult Editar(int id)
        {
            Contato c = _contatoRepositorio.BuscarId(id);
            return View(c);
        }
        #endregion

        #region - Delete
        public IActionResult DeletarConfirmacao(int id)
        {
            Contato c = _contatoRepositorio.BuscarId(id);
            return View(c);
        }
        #endregion
    }
}
