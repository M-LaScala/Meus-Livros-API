using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class CreateLivroDto
{

    [Required(ErrorMessage = "O título é obrigatório!")]
    [StringLength(50)]
    public string Titulo { get; set; }

    [StringLength(50)]
    public string? Autor { get; set; }

    [StringLength(50)]
    public string? Editora { get; set; }

    [Required(ErrorMessage = "A quantidade de páginas é obrigatória!")]
    [Range(1, 5000)]
    public int QtdPaginas { get; set; }

    [Required(ErrorMessage = "O ano de publicação é obrigatório!")]
    public DateTime? AnoDePublicacao { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório!")]
    [StringLength(50)]
    public string? Genero { get; set; }

    [Required(ErrorMessage = "Falta informar se foi lido ou não")]
    public bool? Lido { get; set; }

    [Required(ErrorMessage = "A nota é obrigatório!")]
    [Range(0, 5)]
    public short? Nota { get; set; }

    [StringLength(5000)]
    public string? Review { get; set; }
}
