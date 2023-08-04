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
        CreateMap<Livraria, UpdateLivrariaDto>();
        CreateMap<Livraria, ReadLivrariaDto>();
    }

}
