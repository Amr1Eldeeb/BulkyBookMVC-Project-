using BulkyWebMVC.Data;
using BulkyWebMVC.Models;
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
            List<Category> result  = _context.Categories.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name?.ToLower() ==category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match The Name");
                ModelState.AddModelError("DisplayOrder", "The Name cannot exactly match The Display Order");
            }
          
            if (category is null) return BadRequest();
            if(ModelState.IsValid) //server side to dataannations
            {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index","Category");
            }
            return View("Create", category);
        }
    }
}
