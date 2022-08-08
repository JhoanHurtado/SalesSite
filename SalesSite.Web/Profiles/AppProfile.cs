using AutoMapper;
using SalesSite.Web.Dtos;
using SalesSite.Web.Models;
using SalesSite.Web.Utility;

namespace SalesSite.Web.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<Product, ProductDto>().ReverseMap();
            this.CreateMap<Client, ClientDto>().ReverseMap();
            this.CreateMap<Result, ProductDto>().ReverseMap();
            this.CreateMap<Invoice, InvoiceDto>().ReverseMap();
            this.CreateMap<InvoiceDetail, InvoiceDetailsDto>().ReverseMap();
        }
    }
}
