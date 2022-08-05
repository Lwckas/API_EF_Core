using Microsoft.EntityFrameworkCore;
using API_1.Models;

namespace API_1.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cinema>()
                .HasOne(Cinema => Cinema.Endereco)
                .WithOne(Endereco => Endereco.Cinema)
                .HasForeignKey<Cinema>(cinema => cinema.enderecoId);

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.gerenteId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.filmeId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.cinema)
                .WithMany(cinema => cinema.sessoes)
                .HasForeignKey(sessao => sessao.cinemaId);
        }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }




    }
}
