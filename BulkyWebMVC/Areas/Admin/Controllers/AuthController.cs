using Bulky.Models.Models;
using Bulky.Models.ViewModels;
using BulkyWebMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BulkyWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController(Register register, UserManager<ApplicationUser> appUser, SignInManager<ApplicationUser> signInManager) : Controller
    {
        private readonly Register _register = register;
        private readonly UserManager<ApplicationUser> _userManager = appUser;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;


        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return View(register);

            var emailExists = await _userManager.Users.AnyAsync(u => u.Email == register.Email);
            if (emailExists)
            {
                ModelState.AddModelError("", "Email already exists.");
                return View(register);
            }



            var user = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)

                };
                await _userManager.AddClaimsAsync(user, claims);

                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                
                return RedirectToAction("Index", "Home", new { area = "Customer" });
                

            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is locked. Please try again later.");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View (request);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Logout()
        {
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
    }
}
