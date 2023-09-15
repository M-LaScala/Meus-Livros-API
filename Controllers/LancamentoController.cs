using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LancamentoController
{
    private LivroContext _context;
    private IMapper _mapper;

    public LancamentoController(LivroContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtem varios lancamentos.
    /// </summary>
    /// <param name="skip">Pular</param>
    /// <param name="take">Pegar</param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadLancamentoDto> GetLancamento([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadLancamentoDto>>(_context.Lancamento.Skip(skip).Take(take));
    }

    /// <summary>
    /// Obtem um lancamento pelo id.
    /// </summary>
    /// <param name="id">Id do lancamento</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetLancamentoPorId(int id)
    {
        var lancamento = _context.Lancamento.FirstOrDefault(lancamento => lancamento.id == id);
        if (lancamento == null)
        {
            return NotFound();
        }

        var lancamentoDto = _mapper.Map<ReadLancamentoDto>(lancamento);

        return Ok(lancamentoDto);
    }

    /// <summary>
    /// Adiona um lancamento.
    /// </summary>
    /// <param name="lancamentoDto">Objeto com o campos necessarios para a criação de um lancamento</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarLancamento([FromBody] CreateLancamentoDto lancamentoDto)
    {
        try
        {
            // Mapeando o objeto recebido via jason para um objeto lancamento
            Lancamento lancamento = _mapper.Map<Livro>(lancamentoDto);
            _context.lancamento.Add(lancamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLancamentoPorId), new { lancamento.id }, lancamento);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Atualiza todos os campos do lancamento.
    /// </summary>
    /// <param name="id">Id do lancamento.</param>
    /// <param name="livroDto">Objeto do lancamento.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaLancamento(int id, [FromBody] UpdateLancamentoDto lancamentoDto)
    {
        var lancamento = _context.Lancamento.FirstOrDefault(lancamento => lancamento.id == id);
        if (lancamento == null)
        {
            return NotFound();
        }
        _mapper.Map(lancamentoDto, lancamento);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um campo especifico do lancamento.
    /// </summary>
    /// <param name="id">Id do lancamento.</param>
    /// <param name="patch">Campo do lancamento.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaLancamentoParcial(int id, JsonPatchDocument<UpdateLancamentoDto> patch)
    {
        var lancamento = _context.Lancamento.FirstOrDefault(lancamento => lancamento.id == id);
        if (lancamento == null)
        {
            return NotFound();
        }
        var lancamentoParaAtualizar = _mapper.Map<UpdateLancamentoDto>(lancamento);

        patch.ApplyTo(lancamentoParaAtualizar, ModelState);

        if (!TryValidateModel(lancamentoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(lancamentoParaAtualizar, lancamento);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Apaga um lancamento.
    /// </summary>
    /// <param name="id">Id do lancamento.</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaLancamento(int id)
    {
        var lancamento = _context.Lancamento.FirstOrDefault(lancamento => lancamento.id == id);
        if (lancamento == null)
        {
            return NotFound();
        }

        _context.Lancamento.Remove(lancamento);
        _context.SaveChanges();
        return NoContent();
    }
}
