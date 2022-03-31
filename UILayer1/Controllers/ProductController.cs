using DomainLayer;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UIlayer.Data.ApiServices;


namespace UIlayer.Controllers
{

    public class ProductController : Controller
    {
        Product data = null;
        public ProductController()
        {
            data = new Product();
        }
        public ActionResult Index(int? i)
        {
            IEnumerable<Product> products = ProductApi.GetProduct();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            Product product = ProductApi.GetProduct(id);
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewProductModel product)
        {
            if (ModelState.IsValid)
            {
                data.Id = 0;
                data.Name = product.Name;
                data.Model = product.Model;
                data.Price = product.Price;
                data.Description = product.Description;
                bool result = ProductApi.CreateProduct(data);
            }
            return RedirectToAction("");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = ProductApi.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                bool result = ProductApi.EditProduct(product);
            }
            return RedirectToAction("");
        }
        public ActionResult Delete(int id)
        {
            bool result = ProductApi.DeleteProduct(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
