using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace homework_64_Atai.ViewModels
{

        public class RegisterViewModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]  
        public string Email { get; set; }
            [Required]
        public string UserName { get; set; }
        public string Avatar { get; set; }
           
            public string PhoneNumber { get; set; }
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
