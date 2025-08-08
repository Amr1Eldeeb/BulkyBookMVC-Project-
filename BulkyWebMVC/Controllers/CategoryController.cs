using BulkyWebMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebMVC.Controllers
{
    public class CategoryController : Controller
    {
      private readonly  ApplicationDbContext _context ;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result  = _context.Categories.ToList();
            return View(result);
        }
    }
}
