using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.Data.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Zadejte platnou emailovou adresu")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(30, ErrorMessage = "Zadejte platné heslo", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";


        [Display(Name = "Pamatuj si mě")]
        public bool RememberMe { get; set; }
    }
 }