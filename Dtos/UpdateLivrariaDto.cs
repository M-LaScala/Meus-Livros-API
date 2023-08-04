using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class UpdateLivrariaDto
{
    [Required(ErrorMessage = "O nome é obrigatorio!")]
    public string Nome { get; set; }
}
