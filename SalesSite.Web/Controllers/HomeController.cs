using Microsoft.AspNetCore.Mvc;

namespace SalesSite.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
