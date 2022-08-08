using AutoMapper;
using Product.Dto.Dtos;
using p = Product.Entitie.Entities;
namespace Product.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<p.Product, ProductDto>().ReverseMap();
            this.CreateMap<p.Product, ProductPostDto>().ReverseMap();
        }
    }
}
