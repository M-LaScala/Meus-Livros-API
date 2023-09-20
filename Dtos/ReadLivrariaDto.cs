using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos;

public class ReadLivrariaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ReadEnderecoDto Endereco { get; set; }
    public ICollection<ReadLancamentoDto> Lancamentos { get; set; }
}
