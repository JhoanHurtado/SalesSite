using SalesSite.Web.Interface;
using p = SalesSite.Web.Models;

namespace SalesSite.Web.Services
{
    public class ClientService : ConsumeApiServices<p.Client>, IClientService
    {
        public ClientService(IConfiguration configuration, string dir="Client") : base(configuration, dir)
        {
        }
    }
}
