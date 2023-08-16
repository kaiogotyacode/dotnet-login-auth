using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
