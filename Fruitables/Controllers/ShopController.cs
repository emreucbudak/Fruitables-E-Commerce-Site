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
        [Route("shop/{productName}")]
        public IActionResult ProductDetail(string productName)
        {

            return View("ProductDetail", productName);
        }

    }
}
