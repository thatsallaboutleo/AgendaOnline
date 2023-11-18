using AgendaOnline.Helper.Interface;
using AgendaOnline.Models;
using Newtonsoft.Json;

namespace AgendaOnline.Helper
{
    public class Sessao : ISessao
    {
        #region - Construtor
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor;
        }
        #endregion

        #region - Metodos uteis
        public Usuario BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
        #endregion
    }
}
