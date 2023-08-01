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

}
