using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Monster Laptop", UnitPrice = 2000, UnitsInStock = 5},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Hp Laptop", UnitPrice = 1500, UnitsInStock = 3},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (p.ProductId == product.ProductId)
            //        productToDelete = p;
            //}
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int desiredCategoryId)
        {
            return _products.Where(p => p.CategoryId == desiredCategoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = null;
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                    productToUpdate = p;
            }
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
