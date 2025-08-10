using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebMVC.Controllers
{
    public class CategoryController : Controller
    {
      private readonly  ApplicationDbContext _context ;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {

            _CategoryRepository= categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> result  = _CategoryRepository.GetAll();
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
            _CategoryRepository.Add(category);
                _CategoryRepository.Save();
                TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index","Category");
            }
            return View("Create", category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null || id ==0) return NotFound();

            var category = _CategoryRepository.Get(x=>x.Id== id);
            if(category is null)return NotFound();

            return View("Edit", category);

        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if(ModelState.IsValid)
            {
               _CategoryRepository.Update(category);
                _CategoryRepository.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            Category? category = _CategoryRepository.Get(x=>x.Id ==id);

            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Category? category = _CategoryRepository.Get(x=>x.Id==id);
            if(category is null) return NotFound(); 

          
               _CategoryRepository.Delete(category);
            _CategoryRepository.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            

            
        }
    }
}
