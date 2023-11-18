using AgendaOnline.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AgendaOnline.Controllers
{
    [PagUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
