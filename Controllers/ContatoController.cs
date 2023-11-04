using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    public class ContatoController : Controller
    {
        #region - Contrutor
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        #endregion

        #region - GET
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult DeletarConfirmacao()
        {
            return View();
        }
        #endregion

        #region - POST
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Alterar(Contato contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }
        #endregion

        #region - PUT
        public IActionResult Editar(int id)
        {
            Contato c = _contatoRepositorio.BuscarId(id);
            return View(c);
        }
        #endregion
    }
}
