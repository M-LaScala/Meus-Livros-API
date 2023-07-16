using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LivroController : ControllerBase
{
    private static List<Livro> livros = new List<Livro>();
    private static int id = 0;

    [HttpGet]
    public IEnumerable<Livro> GetLivro([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return livros.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetLivroPorId(int id)
    {
        var livro = livros.FirstOrDefault(livro => livro.id == id);
        if (livro == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(livro);
        }
    }

    [HttpPost]
    public IActionResult CadastrarLivro(Livro livro)
    {
        try
        {
            livro.id = id++;
            livros.Add(livro);
            return CreatedAtAction(nameof(GetLivroPorId), new { id = livro.id }, livro);
        }
        catch
        {
            return BadRequest();
        }
    }
}
