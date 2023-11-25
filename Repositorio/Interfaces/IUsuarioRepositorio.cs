using AgendaOnline.Models;

namespace AgendaOnline.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmailLogin(string login, string email);

        List<Usuario> BuscarTodos();
        Usuario BuscarId(int id);
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        Usuario AlterarSenha(AlterarSenha alterarSenha);
        bool Apagar(int id);
    }
}
