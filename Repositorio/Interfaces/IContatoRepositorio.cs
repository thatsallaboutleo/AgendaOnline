using AgendaOnline.Models;

namespace AgendaOnline.Repositorio.Interfaces
{
    public interface IContatoRepositorio
    {
        Contato Adicionar(Contato contato);
        List<Contato> BuscarTodos();
    }
}
