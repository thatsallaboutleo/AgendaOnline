using AgendaOnline.Filters;
using AgendaOnline.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaOnline.Controllers
{
    [PagUsuarioLogado]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}