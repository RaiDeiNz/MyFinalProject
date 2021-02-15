using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDAL : IProductDAL
    {
        List<Product> _products;
        public InMemoryProductDAL()
        {
            //Oracle,Sql Server, Postgres, MongoDB
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Kitap",UnitPrice=30,UnitsInStock=1000},
                new Product{ProductId=2,CategoryId=1,ProductName="Dergi",UnitPrice=15,UnitsInStock=1000},
                new Product{ProductId=3,CategoryId=3,ProductName="Kumbara",UnitPrice=25,UnitsInStock=1000},
                new Product{ProductId=4,CategoryId=2,ProductName="Kalem",UnitPrice=10,UnitsInStock=1000},
                new Product{ProductId=5,CategoryId=1,ProductName="Defter",UnitPrice=5,UnitsInStock=1000},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query

            /*
            Product productToDelete = null;

            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete= p;
                }
            }
            */

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //Lambda
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ID'sine sahip olan, listedeki ürünü buluyoruz.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
