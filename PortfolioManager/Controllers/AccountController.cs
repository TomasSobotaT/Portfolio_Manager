using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Models.AccountViewModels;

namespace PortfolioManager.Controllers
{
    /// <summary>
    /// Controller for Sign-in and register
    /// </summary>
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }




        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        /// <summary>
        /// Login through post form
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="returnUrl"> parameter ?returnUrl= </param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;


            if (!ModelState.IsValid)
                return View(loginViewModel);
         
            var result = await signInManager.PasswordSignInAsync(
                loginViewModel.Email,loginViewModel.Password,loginViewModel.RememberMe,lockoutOnFailure:false);


            if(result.Succeeded)
            {
                if(returnUrl == null)
                   RedirectToAction("Index", "Home");   // ´

                RedirectToAction(returnUrl);

            }
            ModelState.AddModelError("", "Neplatné přihlašovací údaje");
            return View(loginViewModel);
        
        }



        /// <summary>
        ///  If its valid, redirects to the local URL, otherwise redirects to the Home-Index
        /// </summary>
        /// <param name="url">URL parameter</param>
        /// <returns>Redirection</returns>
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}

