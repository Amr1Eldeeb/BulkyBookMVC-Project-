using AspNetCoreGeneratedDocument;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

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

            return View(products);
        }
        [HttpGet]
        public IActionResult Edit (int Id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == Id);
            return View(product);
        }
    }
}
