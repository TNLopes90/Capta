using AutoMapper;
using Capta.Domain;
using Capta.WebAPI.DTOs;

namespace Capta.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Time, TimeDTO>().ReverseMap();
            CreateMap<Jogador, JogadorDTO>().ReverseMap();
            CreateMap<Habilidade, HabilidadeDTO>().ReverseMap();
        }

    }
}