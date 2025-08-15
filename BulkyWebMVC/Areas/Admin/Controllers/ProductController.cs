using AspNetCoreGeneratedDocument;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
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
        public IActionResult Edit (int Id)
        {
            if(Id == null)return NotFound();
            var product = _unitOfWork.Product.Get(x => x.Id == Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int Id ,Product product)
        {
            if(product is null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            TempData["success"] = "Product Updated Successfully";

            return RedirectToAction("Index");
             
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var product = _unitOfWork.Product.Get(x=>x.Id==Id);
            if (product is null)
                return NotFound();
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
        
            var product = _unitOfWork.Product.Get(x=>x.Id==id);
            if (product is null)
                return NotFound();
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully";

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork
            .Category.GetAll().
            Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });

        ProductVM productVM = new()
        {
            CategoryList = CategoryList,
            Product = new Product()
        };
            return View(productVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            if (product == null)
            {
                product = new ProductVM();
                product.Product = new Product();
            }

            product.CategoryList = _unitOfWork.Category.GetAll().Select(u =>
                new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                    Selected = (u.Id == product.Product.CategoryId)
                });

            return View("Create", product);
        }

    }
}
