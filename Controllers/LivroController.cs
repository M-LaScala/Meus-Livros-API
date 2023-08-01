using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadLivroDto> GetLivro([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadLivroDto>>(_context.Livros.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetLivroPorId(int id)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.id == id);
        if (livro == null)
        {
            return NotFound();
        }

        var livroDto = _mapper.Map<ReadLivroDto>(livro);

        return Ok(livroDto);

    }

    /// <summary>
    /// Adiona um livro ao banco de dados
    /// </summary>
    /// <param name="livroDto">Objeto com o campos necessarios para a criação um livro</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
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

    [HttpPut("{id}")]
    public IActionResult AtualizaLivro(int id, [FromBody] UpdateLivroDto livroDto)
    {
        var livro = _context.Livros.FirstOrDefault(x => x.id == id);
        if (livro == null)
        {
            return NotFound();
        }
        _mapper.Map(livroDto, livro);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaLivroParcial(int id, JsonPatchDocument<UpdateLivroDto> patch)
    {
        var livro = _context.Livros.FirstOrDefault(x => x.id == id);
        if (livro == null)
        {
            return NotFound();
        }

        var livroParaAtualizar = _mapper.Map<UpdateLivroDto>(livro);

        patch.ApplyTo(livroParaAtualizar, ModelState);

        if (!TryValidateModel(livroParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(livroParaAtualizar, livro);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaLivro(int id)
    {
        var livro = _context.Livros.FirstOrDefault(x => x.id == id);
        if (livro == null)
        {
            return NotFound();
        }

        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return NoContent();
    }

}
