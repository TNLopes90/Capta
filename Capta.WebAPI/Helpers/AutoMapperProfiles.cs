using AutoMapper;
using Capta.Domain;
using Capta.Domain.Identity;
using Capta.WebAPI.DTOs;

namespace Capta.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Time, TimeDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Jogador, JogadorDTO>().ReverseMap();
            CreateMap<Habilidade, HabilidadeDTO>().ReverseMap();
        }

    }
}