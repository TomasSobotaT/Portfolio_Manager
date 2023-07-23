using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Zadejte platnou emailovou adresu")]
        [Display(Name ="Email")]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(30,ErrorMessage ="Zadejte platné heslo ({2} až {1} znaků)",MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";

        [Required]
        [Compare("Password", ErrorMessage = "Zadaná hesla se neshodují")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        public string ConfirmPassword { get; set; } = "";

    }
}
