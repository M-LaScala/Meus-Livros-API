namespace MeusLivrosAPI.Models;

public class Livro
{
    public string Nome { get; set; }

    public string? Autor { get; set; }

    public int? Paginas { get; set; }

    public string? Genero { get; set; }

    public bool? Lido { get; set; }

    public short? Review { get; set; }
}
