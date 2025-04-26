using Fruitables.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fruitables.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult TermsOfUse()
        {
            return View();  
        }

        public IActionResult SalesAndRefunds()
        {
            return View(); 
        }

    }
}
