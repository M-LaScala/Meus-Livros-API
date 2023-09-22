using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class CreateEnderecoDto 
{
    [Required(ErrorMessage = "O logradouro é obrigatorio!")]
    public string Logradouro { get; set; }
    public int Numero { get; set; }
}
