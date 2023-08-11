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
    }
}
