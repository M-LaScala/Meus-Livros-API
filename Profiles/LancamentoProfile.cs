using AutoMapper;
using MeusLivrosAPI.Dtos;
using MeusLivrosAPI.Models;

namespace MeusLivrosAPI.Profiles;

public class LancamentoProfile : Profile
{
    public LancamentoProfile()
    {
        CreateMap<CreateLancamentoDto, Lancamento>();
        CreateMap<Lancamento, ReadLancamentoDto>();
    }
}
