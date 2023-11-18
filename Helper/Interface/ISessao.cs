using AgendaOnline.Models;

namespace AgendaOnline.Helper.Interface
{
    public interface ISessao 
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoDoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
