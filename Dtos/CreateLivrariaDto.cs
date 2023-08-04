using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class CreateLivrariaDto
{
    [Required(ErrorMessage = "O nome é obrigatorio!")]
    public string Nome { get; set; }
}
