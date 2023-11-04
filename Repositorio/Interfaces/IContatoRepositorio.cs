using AgendaOnline.Models;

namespace AgendaOnline.Repositorio.Interfaces
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        List<Contato> BuscarTodos();
        Contato BuscarId(int id);
    }
}
