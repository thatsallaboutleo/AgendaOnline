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

        public Contato Atualizar(Contato contato)
        {
            Contato cDb = BuscarId(contato.Id);
            if (cDb == null) throw new Exception("Houve um erro na atualização do contato.");

            cDb.Nome = contato.Nome;
            cDb.Email = contato.Email;
            cDb.Telefone = contato.Telefone;

            _context.Contatos.Update(cDb);
            _context.SaveChanges();
            return cDb;
        }

        public Contato BuscarId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<Contato> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }
    }
}
