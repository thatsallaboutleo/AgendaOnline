using AgendaOnline.Data;
using AgendaOnline.Models;
using AgendaOnline.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaOnline.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext context)
        {
            _context = context;
        }


        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorEmailLogin(string login, string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            Usuario uDb = BuscarId(id);
            if (uDb == null) throw new Exception("Houve um erro na deleção do usuario.");

            _context.Usuarios.Remove(uDb);
            _context.SaveChanges();
            return true;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario uDb = BuscarId(usuario.Id);
            if (uDb == null) throw new Exception("Houve um erro na atualização do usuario.");

            uDb.Nome = usuario.Nome;
            uDb.Email = usuario.Email;
            uDb.Login = usuario.Login;
            uDb.Perfil = usuario.Perfil;
            uDb.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(uDb);
            _context.SaveChanges();

            return uDb;
        }

        public Usuario AlterarSenha(AlterarSenha alterarSenha)
        {
            Usuario usuarioDb = BuscarId(alterarSenha.Id);
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização da senha! Usuário não encontrato");

            if (!usuarioDb.SenhaValidado(alterarSenha.SenhaAtual)) throw new Exception("Senha atual está incorreta!");

            if (usuarioDb.SenhaValidado(alterarSenha.NovaSenha)) throw new Exception("Nova Senha deve ser diferente da senha atual");

            usuarioDb.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDb.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }

        public Usuario BuscarId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }
    }
}
