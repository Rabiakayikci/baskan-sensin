using System.Diagnostics;
using BaskanSensin.Models;
using Microsoft.AspNetCore.Mvc;



namespace BaskanSensin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}