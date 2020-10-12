using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersRegistration.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Length of name must be between 3 and 20")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage ="Invalid email")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirm password fields do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
