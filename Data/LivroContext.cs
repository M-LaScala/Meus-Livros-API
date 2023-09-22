using MeusLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeusLivrosAPI.Data;

public class LivroContext : DbContext
{

    public LivroContext(DbContextOptions<LivroContext> opts) : base(opts)
    {
          
    }

    protected override void OnModelCreating(ModelBuilder Builder)
    {
        /* Definindo manualmente o relacionamento das entidades */

        Builder.Entity<Lancamento>()
            .HasKey(Lancamento => new { Lancamento.LivroId,
                Lancamento.LivrariaId });

        Builder.Entity<Lancamento>()
            .HasOne(Lancamento => Lancamento.Livraria)
            .WithMany(Livraria => Livraria.Lancamentos)
            .HasForeignKey(Lancamento => Lancamento.LivrariaId);

        Builder.Entity<Lancamento>()
            .HasOne(Lancamento => Lancamento.Livro)
            .WithMany(Livro => Livro.Lancamentos)
            .HasForeignKey(Lancamento => Lancamento.LivroId);

        /* Definindo o modo de deleção do endereço para não apagar em cascata outros registros */

        Builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Livraria)
            .WithOne(livraria => livraria.Endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    // Propriedades de acesso a base
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Livraria> Livrarias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Lancamento> Lancamento { get; set; }
}
