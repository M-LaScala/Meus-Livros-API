using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class EnderecoProfile : Profile
{
	public EnderecoProfile()
	{
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, UpdateEnderecoDto>();
        CreateMap<Endereco, ReadEnderecoDto>();
    }
}
