using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LivroController : ControllerBase
{

    private LivroContext _context;
    private IMapper _mapper;

    public LivroController(LivroContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Livro> GetLivro([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _context.Livros.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetLivroPorId(int id)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.id == id);
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
    public IActionResult CadastrarLivro([FromBody] CreateLivroDto livroDto)
    {
        try
        {
            // Mapeando o objeto recebido via jason para um objeto livro
            Livro livro = _mapper.Map<Livro>(livroDto);
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLivroPorId), new { id = livro.id }, livro);
        }
        catch
        {
            return BadRequest();
        }
    }
}
