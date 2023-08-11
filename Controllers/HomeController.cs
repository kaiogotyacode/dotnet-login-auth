using LoginAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            if (TempData.ContainsKey("Usuario"))
            {
                ViewBag.Usuario = TempData["Usuario"] as Usuario;
            }

            return View();
        }
     
    }
}