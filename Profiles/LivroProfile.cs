using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<CreateLivroDto, Livro>();
    }
}
