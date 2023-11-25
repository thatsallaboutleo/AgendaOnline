using AgendaOnline.Data.Map;
using AgendaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaOnline.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}