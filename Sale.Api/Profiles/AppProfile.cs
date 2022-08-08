using AutoMapper;
using Sale.Entitie.Entities;
namespace Sale.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<Invoice, InvoiceDto>().ReverseMap();
            this.CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();
        }
    }
}
