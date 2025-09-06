using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.ViewModels
{

    public class AssignRoleVM
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "At least one role must be selected")]
        public List<string> SelectedRoleNames { get; set; } = new List<string>();

        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }

}
