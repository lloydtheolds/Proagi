using Microsoft.EntityFrameworkCore;
using Proagil.Domain;

namespace Proagil.Repository
{
    public class ProagilContext : DbContext
    {
        public ProagilContext(DbContextOptions<ProagilContext> options) : base (options){}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial>  RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId}); 
        }

        /*
        internal Task FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
        */
    }
}