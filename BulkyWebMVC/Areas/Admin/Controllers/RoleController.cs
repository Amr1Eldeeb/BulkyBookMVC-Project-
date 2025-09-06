using Bulky.Models.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BulkyWebMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _role;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> role,UserManager<ApplicationUser>user)
        {
            _role = role;
            _userManager = user;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult result = await _role.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["success"] = $"Role {roleViewModel.RoleName} is Added Successlfy";
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole", roleViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AssignToRole()
        {
            var roles = await _role.Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name   
                })
                .ToListAsync();

            var vm = new AssignRoleVM
            {
                Roles = roles
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AssignToRole(AssignRoleVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Roles = await _role.Roles
                    .Select(r => new SelectListItem { Text = r.Name, Value = r.Name })
                    .ToListAsync();
                return View(vm);
            }

            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                vm.Roles = await _role.Roles
                    .Select(r => new SelectListItem { Text = r.Name, Value = r.Name })
                    .ToListAsync();
                return View(vm);
            }

            var result = await _userManager.AddToRolesAsync(user, vm.SelectedRoleNames);

            if (result.Succeeded)
            {
                TempData["success"] = $"Assigned roles successfully to {user.Email}";
                return RedirectToAction(nameof(AssignToRole));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            vm.Roles = await _role.Roles
                .Select(r => new SelectListItem { Text = r.Name, Value = r.Name })
                .ToListAsync();

            return View(vm);
        }
    }



}
