using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class LivrariaProfile : Profile
{
    public LivrariaProfile()
    {
        CreateMap<CreateLivrariaDto, Livraria>();
        CreateMap<UpdateLivrariaDto, Livraria>();
        // Mapeando o objeto Endereco de ReadlivrariaDto para o Objeto Endereco de Livraria
        CreateMap<Livraria, ReadLivrariaDto>().
            ForMember(LivrariaDto => LivrariaDto.Endereco,
            opt => opt.MapFrom(livraria => livraria.Endereco));
        CreateMap<Livraria, UpdateLivrariaDto>();

    }

}
