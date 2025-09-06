using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWebMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork,IProductRepository productRepository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _productRepository  = productRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> product = _unitOfWork.Product.GetAllAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.GetWithInclude(id);
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
