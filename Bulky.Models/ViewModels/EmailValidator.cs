using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{
    public class EmailValidator:AbstractValidator<RegisterVM>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.ConfirmPassword).NotEmpty();
        }



    }
}
