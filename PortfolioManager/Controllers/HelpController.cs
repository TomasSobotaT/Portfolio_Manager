using Microsoft.AspNetCore.Mvc;
using PortfolioManager.Models;

namespace PortfolioManager.Controllers
{
    public class HelpController : Controller
    {
        public string RandomPassword()
        {
            var random = new RandomPasswordGenerator();
            var randomPassword = random.Generate();
            return randomPassword;
        }
    }
}
