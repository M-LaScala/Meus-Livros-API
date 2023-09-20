using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        // Permite colocar explicitamente uma consulta ao banco
        return _mapper.Map<List<ReadLivrariaDto>>
            (_context.Livrarias.FromSqlRaw($"select * from livrarias where EnderecoId = {enderecoId}").ToList());
        
    }

    /// <summary>
    /// Obtem uma livraria pelo id.
    /// </summary>
    /// <param name="id">Id do livro</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetLivrariaPorId(int id)
    {
        var livraria = _context.Livrarias.FirstOrDefault(x => x.Id == id);
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
    /// <param name="livrariaDto">Objeto com o campos necessarios para a criação de uma livraria</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarLivraria([FromBody] CreateLivrariaDto livrariaDto)
    {
        try
        {
            // Mapeando o objeto recebido via jason para um objeto livraria
            Livraria livraria = _mapper.Map<Livraria>(livrariaDto);
            //livraria.DataDeGravacao = DateTime.Now;
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
        var livraria = _context.Livrarias.FirstOrDefault(x => x.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }
        //livraria.DataDeAlteracao = DateTime.Now;
        _mapper.Map(livrariaDto, livraria);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um campo especifico da livraria.
    /// </summary>
    /// <param name="id">Id da livraria.</param>
    /// <param name="patch">Campo da livraria.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaLivrariaParcial(int id, JsonPatchDocument<UpdateLivrariaDto> patch)
    {
        var livraria = _context.Livrarias.FirstOrDefault(x => x.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }

        //livraria.DataDeAlteracao = DateTime.Now;
        var livrariaParaAtualizar = _mapper.Map<UpdateLivrariaDto>(livraria);

        patch.ApplyTo(livrariaParaAtualizar, ModelState);

        if (!TryValidateModel(livrariaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(livrariaParaAtualizar, livraria);
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
        var livraria = _context.Livrarias.FirstOrDefault(x => x.Id == id);
        if (livraria == null)
        {
            return NotFound();
        }

        _context.Livrarias.Remove(livraria);
        _context.SaveChanges();
        return NoContent();
    }
}
