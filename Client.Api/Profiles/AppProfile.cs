using AutoMapper;
using Client.Dto.Dtos;
using p = Client.Entities.Entities;
namespace Client.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<p.Client, ClientDto>().ReverseMap();
            this.CreateMap<p.Client, ClientPostDto>().ReverseMap();
        }
    }
}
