using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class CreateLancamentoDto
{
    public int LivroId { get; set; }
    public int LivrariaId { get; set; }
}
