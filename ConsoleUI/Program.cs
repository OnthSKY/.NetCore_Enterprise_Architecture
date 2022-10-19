using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ListProductsDetails();

            //ListCategories(categoryManager);
            //ListPersonels(personelManager);
            //ListProducts(productManager);

        }

        private static void ListProductsDetails()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetProductDetails())
            {
                Console.WriteLine($"{p.ProductId} / {p.ProductName} / {p.CategoryName}");
            }
        }

        private static void ListCategories()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var c in categoryManager.GetAll())
            {
                Console.WriteLine($"{c.CategoryId} / {c.CategoryName}");
            }
        }

        private static void ListPersonels()
        {
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
            foreach (var personel in personelManager.GetAll())
            {
                Console.WriteLine($"{personel.Id} / {personel.Name} {personel.Surname}");
            }
        }

        private static void ListProductsByPrice()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetByUnitPrice(10, 100))
            {
                Console.WriteLine(p.ProductName);
            }
        }

        private static void ListProducts()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetAll())
            {
                Console.WriteLine($"{p.ProductId} / {p.ProductName}");
            }
            Console.WriteLine("------------------");
        }
    }
}
