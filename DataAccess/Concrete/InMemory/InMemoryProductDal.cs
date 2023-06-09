﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDAL
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product { ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product { ProductId=3, CategoryId=1, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product { ProductId=4, CategoryId=1, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product { ProductId=5, CategoryId=1, ProductName="Mouse", UnitPrice=85, UnitsInStock=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            //Product productToDelete=null;

            // foreach (var item in _products)
            // {
            //     if(product.ProductId== item.ProductId) 
            //     { 
            //         productToDelete = item;
            //     }
            // }
            //_products.Remove(productToDelete);


            Product productToDelete  =_products.SingleOrDefault(p=>p.ProductId==product.ProductId);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
           throw new NotImplementedException();
            //return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return  _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate  = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId = product.CategoryId;
        }
    }
}
