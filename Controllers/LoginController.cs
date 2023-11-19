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
        private readonly IEmail _email;


        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //Caso usuario estiver logado
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSeha()
        {
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

        [HttpPost]
        public IActionResult EnviarLinkParaSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario u = _usuarioRepositorio.BuscarPorEmailLogin(redefinirSenha.NomeDeUsuario, redefinirSenha.Email);
                    if (u != null)
                    {
                        string novaSenha = u.GerarNovaSenha();
                        string msg = $"Sua nova senha é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(u.Email, "Agenda Online - Nova Senha", msg);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(u);
                            TempData["MsgSucesso"] = "Enviamos para o e-mail cadastrado a nova senha";
                        }
                        else
                        {
                            TempData["MsgErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente";
                        }
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MsgErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados";
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = $"Algo deu errado! Não foi possivel redefinir sua senha, erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
