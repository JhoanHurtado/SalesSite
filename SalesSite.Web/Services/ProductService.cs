using SalesSite.Web.Interface;
using p = SalesSite.Web.Models;

namespace SalesSite.Web.Services
{
    public class ProductService : ConsumeApiServices<p.Product>, IProductService
    {
        public ProductService(IConfiguration configuration, string dir = "Product") : base(configuration, dir)
        {
        }
    }
}
