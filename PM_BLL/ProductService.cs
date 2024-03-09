using PM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_BLL
{
    public class ProductService
    {
        // The controller calls this method when the user clicks the "See Products" header link
        public List<Product> ReadProductsService()
        {
            // Create a new instance of the ProductRepository class
            ProductRepository productRepository = new ProductRepository();

            // Call the GetProductsRepository method of the productRepository object
            var products = productRepository.ReadProductsRepository();

            // Return the products object
            return products;
        }

        // This methods Validates the productToAdd fields 
        public bool ValidateProduct(Product productToValidate)
        {
            // Validate the productToAdd fields
            if (productToValidate.ProductName != null &&
                productToValidate.ProductDescription != null &&
                productToValidate.ProductPrice > 0 &&
                productToValidate.ProductQuantity > 0 &&
                productToValidate.ProductCategory != null &&
                productToValidate.ProductSupplier != null)
            {
                // Return true if the productToAdd fields are valid
                return true;
            }
            return false;
        }

        // The controller calls this method when the user clicks the "Add Product" button
        public bool CreateProductService(Product productToCreate)
        {
            // Create a new instance of the ProductRepository class
            ProductRepository productRepository = new ProductRepository();

            // Call the AddProductRepository method of the productRepository object
            var productCreated = productRepository.CreateProductRepository(productToCreate);

            // Validate the productAdded fields 
            if (ValidateProduct(productToCreate))
            {
                // Return the productAdded object if it passes validation
                return productCreated;
            }
            // Return false if the productAdded object does not pass validation
            return false;
        }

        /// <summary>
        /// This method receives a productToUpdate object as parameter
        /// and calls the UpdateProductRepository method of the productRepository object
        /// Then it validates the productToUpdate object using the ValidateProduct method
        /// and returns the productUpdated object if it passes validation
        /// </summary>
        /// <param name="productToUpdate"></param>
        /// <returns></returns>
        public bool UpdateProductService(Product productToUpdate)
        {
            ProductRepository productRepository = new ProductRepository();

            if (ValidateProduct(productToUpdate))
            {
                return productRepository.UpdateProductRepository(productToUpdate);
            }
            return false;
        }

        // The controller calls this method when the user click the "Edit Product" button
        public Product GetProductByIdService(int productId)
        {
            // Create a new instance of the ProductRepository class
            ProductRepository productRepository = new ProductRepository();

            // Call the GetProductByIdRepository method of the productRepository object
            var product = productRepository.GetProductByIdRepository(productId);

            // Return the product object
            return product;
        }

        public bool DeleteProductService(int tripId)
        {
            ProductRepository productRepository = new ProductRepository();

            return productRepository.DeleteProductRepository(tripId);
        }
    }
}
