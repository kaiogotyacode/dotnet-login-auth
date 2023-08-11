using LoginAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Usuario usuario)
        {
           

            return RedirectToAction("Index","Home");
        }
    }
}
