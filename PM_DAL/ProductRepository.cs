using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_DAL
{
    public class ProductRepository
    {
        // The ProductService class calls this method when the user clicks the "See Products" header link
        public List<Product> ReadProductsRepository()
        {
            // Create a new instance of the InventoryEntities1 class
            InventoryEntities1 inventoryEntities = new InventoryEntities1();

            // Create a new list of Product objects and set it equal to the Products table in the database
            var products = inventoryEntities.Products.ToList();

            // Return the products object
            return products;
        }

        // The ProductService class calls this method when the user clicks the "Add Product" button
        public bool CreateProductRepository(Product productToCreate)
        {
            // Create a new instance of the InventoryEntities1 class
            InventoryEntities1 inventoryEntities = new InventoryEntities1();

            // Validate the productToAdd object and add it to the Products table in the database
            if (productToCreate != null)
            {
                // Call the Add method of the Products property of the inventoryEntities object
                inventoryEntities.Products.Add(productToCreate);

                // Save the changes to the database
                inventoryEntities.SaveChanges();

                return true;
            }

            // Return false if the productToAdd object is null
            return false;
        }

        // The ProductService class calls this method when the user clicks the "Edit Product" button
        public bool UpdateProductRepository(Product productToUpdate)
        {
            // Create a new instance of the InventoryEntities1 class
            InventoryEntities1 inventoryEntities = new InventoryEntities1();

            Product productToBeUpdated = null;

            productToBeUpdated = inventoryEntities.Products.FirstOrDefault(x => x.ProductId == productToUpdate.ProductId);

            if (productToBeUpdated != null)
            {
                // Call the Map method of the Mapper class to map the productToUpdate object to the productToBeUpdated object
                Mapper.Map(productToUpdate, productToBeUpdated);

                // Save the changes to the database
                inventoryEntities.SaveChanges();

                return true;
            }
            return false;
        }

        public Product GetProductByIdRepository(int productId)
        {
            // Create a new instance of the InventoryEntities1 class
            InventoryEntities1 inventoryEntities = new InventoryEntities1();

            // Create a new Product object and set it equal to the ProductId in the Products table in the database
            var product = inventoryEntities.Products.FirstOrDefault(x => x.ProductId == productId);

            // Return the product object
            return product;
        }



        public bool DeleteProductRepository(int productId)
        {
            InventoryEntities1 inventoryEntities = new InventoryEntities1();

            var product = inventoryEntities.Products.Where(x => x.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                inventoryEntities.Products.Remove(product);
                inventoryEntities.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
