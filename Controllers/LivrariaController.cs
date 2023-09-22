using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LivrariaController : ControllerBase
{
    private LivroContext _context;
    private IMapper _mapper;

    public LivrariaController(LivroContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtem varias livrarias.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadLivrariaDto> GetLivrarias([FromQuery] int? enderecoId = null)
    {
        if (enderecoId == null)
        {
            return _mapper.Map<List<ReadLivrariaDto>>(_context.Livrarias.ToList());
        }

        return _mapper.Map<List<ReadLivrariaDto>>
            (_context.Livrarias.FromSqlRaw($"select * from livrarias where EnderecoId = {enderecoId}").ToList());
        
    }

    /// <summary>
    /// Obtem uma livraria pelo id.
    /// </summary>
    /// <param name="id">Id da livraria.</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetLivrariaPorId(int id)
    {
        var livraria = _context.Livrarias.FirstOrDefault(livraria => livraria.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }

        var livrariaDto = _mapper.Map<ReadLivrariaDto>(livraria);

        return Ok(livrariaDto);

    }

    /// <summary>
    /// Adiona uma livraria.
    /// </summary>
    /// <param name="livrariaDto">Objeto com o campos necessarios para a criação de uma livraria.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarLivraria([FromBody] CreateLivrariaDto livrariaDto)
    {
        try
        {
            Livraria livraria = _mapper.Map<Livraria>(livrariaDto);
            _context.Livrarias.Add(livraria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLivrariaPorId), new { livraria.Id }, livraria);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Atualiza todos os campos da livraria.
    /// </summary>
    /// <param name="id">Id da livraria.</param>
    /// <param name="livrariaDto">Objeto da livraria.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaLivraria(int id, [FromBody] UpdateLivrariaDto livrariaDto)
    {
        var livraria = _context.Livrarias.FirstOrDefault(livraria => livraria.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }
        _mapper.Map(livrariaDto, livraria);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Apaga uma livraria.
    /// </summary>
    /// <param name="id">Id da livraria.</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaLivraria(int id)
    {
        var livraria = _context.Livrarias.FirstOrDefault(livraria => livraria.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }

        _context.Livrarias.Remove(livraria);
        _context.SaveChanges();
        return NoContent();
    }
}
