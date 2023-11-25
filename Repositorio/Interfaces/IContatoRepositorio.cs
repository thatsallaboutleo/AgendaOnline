using AgendaOnline.Models;

namespace AgendaOnline.Repositorio.Interfaces
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        bool Apagar(int id);
        List<Contato> BuscarTodos(int usuarioId);
        Contato BuscarId(int id);
    }
}
