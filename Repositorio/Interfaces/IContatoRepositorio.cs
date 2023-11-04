using AgendaOnline.Models;

namespace AgendaOnline.Repositorio.Interfaces
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        bool Apagar(int id);
        List<Contato> BuscarTodos();
        Contato BuscarId(int id);
    }
}
