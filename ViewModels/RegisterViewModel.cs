using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace homework_64_Atai.ViewModels
{

        public class RegisterViewModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [Remote(action: "EmailValid", controller: "Account", ErrorMessage = "Этот Email уже занят")]
        public string Email { get; set; }
            [Required]
            [Remote(action: " NameValid", controller: "Account", ErrorMessage = "Этот Name уже занят")]
        public string UserName { get; set; }
        public string Avatar { get; set; }

        [Required]
        [Remote(action: " PhoneNumberValid", controller: "Account", ErrorMessage = "Этот Phone Number уже занят")]
        public string PhoneNumber { get; set; }
        [Required]
            public string Role { get; set; }
            
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }

        }

}
