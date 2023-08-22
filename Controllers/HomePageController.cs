using Microsoft.AspNetCore.Mvc;

namespace MarketingApp.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAddress()
        {
            return View();
        }
        public IActionResult AddAddressForm()
        {
            return View();
        }
    }
}
