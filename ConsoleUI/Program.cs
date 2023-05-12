using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            ProductTest2();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryId + " --> " + item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (var item in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(item.ProductName + " --> " + item.UnitPrice);
            }
        }

        private static void ProductTest2()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + " --> " + item.CategoryName);
            }
        }
    }
}
