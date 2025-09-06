using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
namespace BulkyWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context,IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment )
        {
            _webHostEnvironment = webHostEnvironment; // to access on Folders 
            _unitOfWork = unitOfWork;   
            _context = context; 
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll();

            IEnumerable<SelectListItem>CategoryList = _unitOfWork
                .Category.GetAll().Select(u=> 
                new SelectListItem { Text = u.Name ,Value=u.Id.ToString()});

            return View(products);
        }
        [HttpGet]
        public IActionResult Edit (int? Id)
        {
            if(Id == null)return NotFound();

            var product = _unitOfWork.Product.Get(x => x.Id == Id);
            ViewBag.ListOfCategory = _unitOfWork.Category.GteSelectList();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int Id ,Product product,IFormFile? file)
        {
            if(product is null)
            {
                return NotFound();
            }

            string wwwRootpath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootpath, @"Images\Product");
                using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                product.ImageUrl = @"\images\Product\" + filename;
            }
           
                _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            TempData["success"] = "Product Updated Successfully";

            return RedirectToAction("Index");
             
        }
        //[HttpGet]
        //public IActionResult Delete(int Id)
        //{
        //    var product = _unitOfWork.Product.Get(x=>x.Id==Id);
        //    if (product == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    return View(product);
        //}
        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
        
            var product = _unitOfWork.Product.Get(x=>x.Id==id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            
            TempData["success"] = "Product Deleted Successfully";
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                string filePath = Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return Json(new { success = true, message = "Product deleted successfully" });

        }
        [HttpGet]
        public IActionResult Create()
        {
            var CategoryList = _unitOfWork.Category.GteSelectList();
 
            ViewData["ListOfCategory"] = CategoryList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootpath = _webHostEnvironment.WebRootPath;
                if(file !=null)
                {
                    string filename  = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath  = Path.Combine(wwwRootpath,@"Images\Product");
                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }                                       
                    product.ImageUrl =@"\images\Product\"+filename;
                }
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ListOfCategory = _unitOfWork.Category.GteSelectList();
            return View(product);
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var objsfromDb = _context.Products.Include(x => x.Category).ToList();

            return Json(new  { data = objsfromDb});

        }








        #endregion

    }
}
