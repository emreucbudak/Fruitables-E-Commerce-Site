using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DiscountPage()
        {
            return View();
        }
    }
}
