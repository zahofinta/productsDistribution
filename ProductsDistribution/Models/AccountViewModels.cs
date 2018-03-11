using DataAnnotationsExtensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace ProductsDistribution.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel 
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

       
       
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Имейл:")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Паролата {0} трябва да бъде поне {2} символа дълга.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете паролата:")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Паролата и потвърдената парола не съвпадат.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Име:")]
        public string first_name { get; set; }
        [Required]
        [Display(Name = "Фамилия:")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Пол:")]
        //public Gender gender { get; set; }
        public string gender { get; set; }
        
        [Required]
        [Display(Name = "Години:")]
        [Min(1, ErrorMessage = "Въведете възраст по-голяма от 1")]
        public int years { get; set; }
        [Required]
        [Display(Name = "Адрес:")]
        public string post_address { get; set; }
        [Required]
        [Display(Name = "Организация:")]
        public string organization { get; set; }
        [Display(Name = "Отдел:")]
        public string department { get; set; }

    }

    public class EditProfileViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Имейл:")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "Паролата {0} трябва да бъде поне {2} символа дълга.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Парола:")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Потвърдете паролата:")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Паролата и потвърдената парола не съвпадат.")]
        //public string ConfirmPassword { get; set; }

        //[Required]
        //[Display(Name = "Име:")]
        //public string first_name { get; set; }
        [Required]
        [Display(Name = "Фамилия:")]
        public string surname { get; set; }
        //[Required]
        //[Display(Name = "Пол:")]
        //public Gender gender { get; set; }
        //public string gender { get; set; }

        //[Required]
        //[Display(Name = "Години:")]
        //[Min(1, ErrorMessage = "Въведете възраст по-голяма от 1")]
        //public int years { get; set; }
        [Required]
        [Display(Name = "Адрес:")]
        public string post_address { get; set; }
        [Required]
        [Display(Name = "Организация:")]
        public string organization { get; set; }
        [Display(Name = "Отдел:")]
        public string department { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
