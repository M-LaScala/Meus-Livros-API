using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Models;

public class Lancamento
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int LivroId { get; set; }
    public virtual Livro Livro { get; set; }
    public int? LivrariaId { get; set; }
    public virtual Livraria Livraria { get; set; }
    
}
