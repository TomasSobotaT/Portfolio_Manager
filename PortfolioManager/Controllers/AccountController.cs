using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Data.Models;
using PortfolioManager.Data.Models.AccountViewModels;

namespace PortfolioManager.Controllers
{
    /// <summary>
    /// Controller for Sign-in and register
    /// </summary>
    public class AccountController : Controller
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
		private readonly ILogger<HomeController> _logger;


		public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			_logger = logger;
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


			if (result.Succeeded)
				return RedirectToLocal(returnUrl);
			


			ModelState.AddModelError("", "Neplatné přihlašovací údaje");
            return View(loginViewModel);
        
        }


		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register(string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			return View();
		}

		/// <summary>
		/// Register through post form
		/// </summary>
		/// <param name="registerViewModel"></param>
		/// <param name="returnUrl"> parameter ?returnUrl= </param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;


            try { 
            if (!ModelState.IsValid)
                return View(registerViewModel);

			
				var user = new ApplicationUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
				var result = await userManager.CreateAsync(user, registerViewModel.Password);

				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);
					    return RedirectToLocal(returnUrl);
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
            }

            catch(Exception ex) {

               
                return BadRequest(ex.ToString());

            }
			

			return View(registerViewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync(); 

         
            return RedirectToAction("Index", "Home");
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

