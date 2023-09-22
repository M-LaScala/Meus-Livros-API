using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class LivrariaProfile : Profile
{
    public LivrariaProfile()
    {
        CreateMap<CreateLivrariaDto, Livraria>();
        CreateMap<Livraria, ReadLivrariaDto>()
            .ForMember(LivrariaDto => LivrariaDto.Endereco,
            opt => opt.MapFrom(livraria => livraria.Endereco))
            .ForMember(LivrariaDto => LivrariaDto.Lancamentos,
            opt => opt.MapFrom(livraria => livraria.Lancamentos));
        CreateMap<UpdateLivrariaDto, Livraria>();
    }

}
