using MeusLivrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeusLivrosAPI.Data;

public class LivroContext : DbContext
{

    public LivroContext(DbContextOptions<LivroContext> opts) : base(opts)
    {
          
    }

    // Propriedade de acesso a base
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Livraria> Livrarias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}
