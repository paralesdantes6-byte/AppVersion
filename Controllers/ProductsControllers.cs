using Microsoft.AspNetCore.Mvc;

using AppVersion.Data;

using AppVersion.Models;

 

namespace AppVersion.Controllers

{

    public class ProductsController : Controller

    {

        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db) { _db = db; }

 

        // shows the list

        public IActionResult Index()

        {

            var products = _db.Product.ToList();

            return View(products);

        }

 

        // shows the empty add-form

        public IActionResult Create()

        {

            return View();

        }

 

        // saves a new product

        [HttpPost]

        public IActionResult Create(Product product)

        {

            _db.Product.Add(product);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

    }

}