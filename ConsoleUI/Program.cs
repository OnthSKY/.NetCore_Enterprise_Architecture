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
            //ListProductsDetails();

            //ListCategories();
            // ListPersonels();
            //ListProducts();

        }

       /* private static void ListProductsDetails()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetProductDetails().Data)
            {
                Console.WriteLine($"{p.ProductId} / {p.ProductName} / {p.CategoryName}");
            }
        }

        private static void ListCategories()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var c in categoryManager.GetAll().Data)
            {
                Console.WriteLine($"{c.CategoryId} / {c.CategoryName}");
            }
        }

        private static void ListPersonels()
        {
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
            var result = personelManager.GetAll();
            foreach (var personel in result.Data)
            {
                Console.WriteLine($"{personel.Id} / {personel.Name}_{personel.Surname}");
            }
        }

        private static void ListProductsByPrice()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetByUnitPrice(10, 100).Data)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        private static void ListProducts()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetAll().Data)
            {
                Console.WriteLine($"{p.ProductId} / {p.ProductName}");
            }
            Console.WriteLine("------------------");
        }*/
    }
}
