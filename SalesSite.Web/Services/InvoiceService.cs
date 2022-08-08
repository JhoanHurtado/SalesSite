using SalesSite.Web.Interface;
using p = SalesSite.Web.Models;

namespace SalesSite.Web.Services
{
    public class InvoiceService : ConsumeApiServices<p.Invoice>, IInvoiceService
    {
        public InvoiceService(IConfiguration configuration, string dir="Invoice") : base(configuration, dir)
        {
        }
    }
}
