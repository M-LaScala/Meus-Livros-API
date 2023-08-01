using System.ComponentModel.DataAnnotations;

namespace MeusLivrosAPI.Dtos
{
    public class ReadLivroDto
    {
        public string Titulo { get; set; }

        public string? Autor { get; set; }

        public string? Editora { get; set; }

        public int QtdPaginas { get; set; }

        public DateTime? AnoDePublicacao { get; set; }

        public string? Genero { get; set; }

        public bool? Lido { get; set; }

        public short? Nota { get; set; }

        public string? Review { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
