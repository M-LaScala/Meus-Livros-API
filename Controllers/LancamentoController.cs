using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class LancamentoController : ControllerBase
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
    /// <param name="livroId">Id de um livro.</param>
    /// <param name="livrariaId">Id de uma livraria.</param>
    /// <returns></returns>
    [HttpGet("{livroId}/{livrariaId}")]
    public IActionResult GetLancamentoPorId(int livroId, int livrariaId)
    {
        Lancamento lancamento = _context.Lancamento
            .FirstOrDefault(lancamento => lancamento.LivroId == livroId &&
                                          lancamento.LivrariaId == livrariaId);

        if (lancamento != null)
        {
            ReadLancamentoDto lancamentoDto = _mapper.Map<ReadLancamentoDto>(lancamento);

            return Ok(lancamentoDto);
        }

        return NotFound();
        
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
            Lancamento lancamento = _mapper.Map<Lancamento>(lancamentoDto);
            _context.Lancamento.Add(lancamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLancamentoPorId), new 
                   { livroId = lancamento.LivroId,
                     livrariaId = lancamento.LivrariaId}, 
                     lancamento);
        }
        catch
        {
            return BadRequest();
        }
    }
}
