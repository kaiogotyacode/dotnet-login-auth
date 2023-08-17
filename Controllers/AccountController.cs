using LoginAuth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuth.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        #region [Post] SignUp
        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var accountCreation = await _userManager.CreateAsync(new IdentityUser() { UserName = userVM.Username }, userVM.Password);

                if (accountCreation.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(userVM);
        }
        #endregion


        public IActionResult SignIn()
        {
            return View();
        }

        #region [Post] SignIn
        [HttpPost]
        public async Task<IActionResult> SignIn(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userVM.Username);
                if (user != null)
                {
                    var loginStatus = await _signInManager.PasswordSignInAsync(user, userVM.Password, false, false);
                    if (loginStatus.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }

            return View(userVM);
        }
        #endregion


        #region Logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return StatusCode(200);
        }

        #endregion
    }
}
