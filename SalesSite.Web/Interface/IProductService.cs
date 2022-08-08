using p = SalesSite.Web.Models;

namespace SalesSite.Web.Interface
{
    public interface IProductService: IConsumeApi<p.Product>
    {
    }
}
