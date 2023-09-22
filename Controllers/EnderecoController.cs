using AutoMapper;
using MeusLivrosAPI.Data;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class EnderecoController : ControllerBase
{
    private LivroContext _context;
    private IMapper _mapper;

    public EnderecoController(LivroContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtem varios enderecos.
    /// </summary>
    /// <param name="skip">Pular.</param>
    /// <param name="take">Pegar.</param>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetEndereco([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }

    /// <summary>
    /// Obtem um endereco pelo id.
    /// </summary>
    /// <param name="id">Id do endereco.</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }

        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

        return Ok(enderecoDto);

    }

    /// <summary>
    /// Adiona um endereco.
    /// </summary>
    /// <param name="enderecoDto">Objeto com o campos necessarios para a criação de um endereco.</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CadastrarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        try
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnderecoPorId), new { endereco.Id }, endereco);
        }
        catch
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Atualiza todos os campos do endereco.
    /// </summary>
    /// <param name="id">Id do endereco.</param>
    /// <param name="enderecoDto">Objeto do endereco.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza um campo especifico do endereco.
    /// </summary>
    /// <param name="id">Id do endereco.</param>
    /// <param name="patch">Campo do endereco.</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }

        var enderecoParaAtualizar = _mapper.Map<UpdateEnderecoDto>(endereco);

        patch.ApplyTo(enderecoParaAtualizar, ModelState);

        if (!TryValidateModel(enderecoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(enderecoParaAtualizar, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Apaga um endereco.
    /// </summary>
    /// <param name="id">Id do endereco.</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
