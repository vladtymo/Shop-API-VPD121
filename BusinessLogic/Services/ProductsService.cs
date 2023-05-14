using BusinessLogic.Interfaces;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext context;

        public ProductsService(ShopDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            if (id < 0) return null; // Bad Request: 400
            var product = context.Products.Find(id);

            if (product == null) return null; // Not Found: 404
            return product;
        }
        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Edit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = GetById(id);

            if (product == null) return; // Not Found: 404

            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
