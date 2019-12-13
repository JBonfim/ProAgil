

using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;

namespace ProAgil.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base (options){ }

         public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestrateEvento> PalestrateEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestrateEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}