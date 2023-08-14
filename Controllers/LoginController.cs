using LoginAuth.Models;
using LoginAuth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {

            return View(new UsuarioViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel userVM)
        {
            if (!ModelState.IsValid)
                return View(userVM);

            var user = await _userManager.FindByNameAsync(userVM.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(userVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(userVM.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Falha ao realizar o login");
            ModelState.ClearValidationState("ReturnUrl");
            return View(userVM);
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UsuarioViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = userVM.Username };
                var result = await _userManager.CreateAsync(user, userVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Login");   
                }

                ModelState.AddModelError("Registro", "Falha ao cadastrar usuário");
                ModelState.ClearValidationState("ReturnUrl");
            }

            return View(userVM);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}
