using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Length(8,20,ErrorMessage ="The Length of Password is 8 to 20")]
        public string Password { get; set; } =string.Empty;
        [Required]
        [Length(8,20,ErrorMessage ="The Length of Password is 8 to 20")]
        public string ConfirmPassword { get; set; } =string.Empty ;

        
    }
}
