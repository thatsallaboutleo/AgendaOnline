using AgendaOnline.Data;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;

namespace AgendaOnline.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;

        public ContatoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public Contato Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }
    }
}
