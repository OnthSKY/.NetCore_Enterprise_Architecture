﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ListProducts(productManager);
            productManager.Add(new Product
            {
                ProductId = 10,
                ProductName ="Iphone 14"
            });
            ListProducts(productManager);
            productManager.Update(new Product
            {
                ProductId = 10,
                ProductName = "Iphone 14 PRO MAX"
            });
            ListProducts(productManager);
            productManager.Delete(new Product
            {
                ProductId = 10
            });
            ListProducts(productManager);
        }

        private static void ListProducts(ProductManager productManager)
        {
            foreach (var p in productManager.GetAll())
            {
                Console.WriteLine(p.ProductName);
            }
            Console.WriteLine("------------------");
        }
    }
}