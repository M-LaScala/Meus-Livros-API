using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public virtual Livraria Livraria { get; set; }
}
