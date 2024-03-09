using AutoMapper;
using PM_BLL;
using PM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // This method is called when the user clicks the "See Products" header link
        [HttpGet]
        public JsonResult ReadProductsController()
        {
            // Create a new instance of the ProductService class
            ProductService productService = new ProductService();

            // Call the GetProductsService method of the productService object
            var products = productService.ReadProductsService();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // This method is called when the user clicks the "Add Product" button
        [HttpPost]
        public JsonResult CreateProductController(Product productToAdd)
        {
            // Create a new instance of the ProductService class
            ProductService productService = new ProductService();

            // Call the AddProductService method of the productService object
            var productAdded = productService.CreateProductService(productToAdd);

            // Return the productAdded object as a JSON object
            return Json(productAdded, JsonRequestBehavior.AllowGet);
        }

        // This method is called when the user clicks the "Edit Product" button
        [HttpPost]
        public JsonResult UpdateProductController(Product productToEdit)
        {
            ProductService productService = new ProductService();
            var productEdited = productService.UpdateProductService(productToEdit);
            return Json(productEdited, JsonRequestBehavior.AllowGet);
        }

        // This method is called when the user click the "Edit Product" button
        [HttpGet]
        public JsonResult ReadProductByIdController(int productId)
        {
            // Create a new instance of the ProductService class
            ProductService productService = new ProductService();

            // Call the GetProductByIdService method of the productService object
            var product = productService.GetProductByIdService(productId);

            // Return the product object as a JSON object
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteProductController(int productId)
        {
            ProductService productService = new ProductService();
            if (productService.DeleteProductService(productId))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}