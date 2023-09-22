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

    /// <summary>
    /// Obtem varios livros.
    /// </summary>
    /// <param name="skip">Pular.</param>
    /// <param name="take">Pegar.</param>
    /// <param name="nomeLivraria">Nome da livraria para o filtro.</param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadLivroDto> GetLivro([FromQuery] int skip = 0, 
                                              [FromQuery] int take = 20,
                                              [FromQuery] string? nomeLivraria = null)
    {
        if(nomeLivraria == null)
        {
            return _mapper.Map<List<ReadLivroDto>>(_context.Livros.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadLivroDto>>(_context.Livros.Skip(skip).Take(take)
            .Where(livro => livro.Lancamentos.Any(lancamento => lancamento.Livraria.Nome == nomeLivraria)).ToList());
    }

    /// <summary>
    /// Obtem um livro pelo id.
    /// </summary>
    /// <param name="id">Id do livro.</param>
    /// <returns></returns>
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
    /// Adiona um livro.
    /// </summary>
    /// <param name="livroDto">Objeto com o campos necessarios para a criação de um livro.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarLivro([FromBody] CreateLivroDto livroDto)
    {
        try
        {
            // Mapeando o objeto recebido via jason para um objeto livro
            Livro livro = _mapper.Map<Livro>(livroDto);
            livro.DataDeGravacao = DateTime.Now;
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLivroPorId), new { livro.id }, livro);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Atualiza todos os campos do livro.
    /// </summary>
    /// <param name="id">Id do livro.</param>
    /// <param name="livroDto">Objeto do livro.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaLivro(int id, [FromBody] UpdateLivroDto livroDto)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.id == id);
        if (livro == null)
        {
            return NotFound();
        }
        livro.DataDeAlteracao = DateTime.Now;
        _mapper.Map(livroDto, livro);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um campo especifico do livro.
    /// </summary>
    /// <param name="id">Id do livro.</param>
    /// <param name="patch">Campo do livro.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaLivroParcial(int id, JsonPatchDocument<UpdateLivroDto> patch)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.id == id);
        if (livro == null)
        {
            return NotFound();
        }

        livro.DataDeAlteracao = DateTime.Now;
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

    /// <summary>
    /// Apaga um livro.
    /// </summary>
    /// <param name="id">Id do livro.</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaLivro(int id)
    {
        var livro = _context.Livros.FirstOrDefault(livro => livro.id == id);
        if (livro == null)
        {
            return NotFound();
        }

        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return NoContent();
    }

}
