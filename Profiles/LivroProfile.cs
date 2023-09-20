using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<CreateLivroDto, Livro>();
        CreateMap<UpdateLivroDto, Livro>();
        CreateMap<Livro, UpdateLivroDto>();
        CreateMap<Livro, ReadLivroDto>()
            .ForMember(LivroDto => LivroDto.Lancamentos,
            opt => opt.MapFrom(livro => livro.Lancamentos));;
    }
}
