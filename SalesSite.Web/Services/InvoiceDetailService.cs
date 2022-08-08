using SalesSite.Web.Interface;
using p = SalesSite.Web.Models;

namespace SalesSite.Web.Services
{
    public class InvoiceDetailService : ConsumeApiServices<p.InvoiceDetail>, IInvoiceDetailService
    {
        public InvoiceDetailService(IConfiguration configuration, string dir="InvoiceDetail") : base(configuration, dir)
        {
        }
    }
}
