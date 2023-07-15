using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LivroController : ControllerBase
{
    private static List<Livro> livros = new List<Livro>();

    [HttpGet]
    public IEnumerable<Livro> GetLivro()
    {
        return livros;
    }

    [HttpGet("{id}")]
    public Livro? GetLivroPorId(int id)
    {
        return livros.FirstOrDefault(livro => livro.id == id);
    }

    [HttpPost]
    public IActionResult CadastrarLivro(Livro livro)
    {
        try
        {
            livro.id++;
            livros.Add(livro);
            Console.WriteLine(livro.Titulo);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
