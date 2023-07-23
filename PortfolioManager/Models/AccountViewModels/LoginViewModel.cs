﻿using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Zadejte platnou emailovou adresu")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(30, ErrorMessage = "Zadejte platné heslo ({2} až {1} znaků)", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";


        [Display(Name = "Pamatuj si mě")]
        public bool RememberMe { get; set; }
    }
 }