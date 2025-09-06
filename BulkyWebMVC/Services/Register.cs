using Bulky.Models.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebMVC.Services
{
    public  class Register
    {
        private readonly UserManager<ApplicationUser> _user;

        public Register(UserManager<ApplicationUser>User)
        {
            _user = User;
        }
        public async Task<IdentityResult> Regsister(RegisterVM request)
        {
            // تحقق من الإيميل
            var EmailIsExist = await _user.Users.AnyAsync(x => x.Email == request.Email);
            if (EmailIsExist)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Email already exists."
                });
            }

            if (request.Password != request.ConfirmPassword)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Passwords do not match."
                });
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _user.CreateAsync(user, request.Password);
            return result;
        }






    
}
}
