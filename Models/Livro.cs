using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Models;

public class Livro
{
   
    [Key]
    [Required]
    public int id { get; internal set; }

    [Required(ErrorMessage = "O título é obrigatório!")]
    [MaxLength(50)]
    public string Titulo { get; set; }

    [MaxLength(50)]
    public string? Autor { get; set; }

    [MaxLength(50)]
    public string? Editora { get; set; }

    [Required(ErrorMessage = "A quantidade de páginas é obrigatória!")]
    [Range(1,5000)]
    public int QtdPaginas { get; set; }

    [Required(ErrorMessage = "O ano de publicação é obrigatório!")]
    public DateTime? AnoDePublicacao { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório!")]
    [MaxLength (50)]
    public string? Genero { get; set; }

    [Required(ErrorMessage = "Falta informar se foi lido ou não.")]
    public bool? Lido { get; set; }

    [Required(ErrorMessage = "A nota é obrigatório!")]
    [Range(0,5)]
    public short? Nota { get; set; }

    [MaxLength(5000)]
    public string? Review { get; set; }

    public DateTime? DataDeGravacao { get; set; }

    public DateTime? DataDeAlteracao { get; set; }
    
    public virtual ICollection<Lancamento> Lancamentos { get; set; }
}