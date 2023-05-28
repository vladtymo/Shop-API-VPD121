using AutoMapper;
using BusinessLogic.ApplicationExceptions;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public ProductsService(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = context.Products.Include(x => x.Category).ToList();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto? GetById(int id)
        {
            if (id < 0) 
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest); // Bad Request: 400
            
            var product = context.Products.Find(id);

            if (product == null) 
                throw new HttpException(ErrorMessages.ProductNotFound, HttpStatusCode.NotFound); // Not Found: 404

            // convert Entity.Product to Product DTO
            //return new ProductDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Discount = product.Discount,
            //    ImageUrl = product.ImageUrl,
            //    InStock = product.InStock,
            //    Price = product.Price,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category?.Name
            //};

            // mapping
            return mapper.Map<ProductDto>(product);
        }
        public void Create(ProductDto dto)
        {
            context.Products.Add(mapper.Map<Product>(dto));
            context.SaveChanges();
        }

        public void Edit(ProductDto dto)
        {
            context.Products.Update(mapper.Map<Product>(dto));
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id < 0) 
                throw new HttpException(ErrorMessages.InvalidId, HttpStatusCode.BadRequest); // Bad Request: 400

            var product = GetById(id);

            if (product == null) 
                throw new HttpException(ErrorMessages.ProductNotFound, HttpStatusCode.NotFound); // Not Found: 404

            context.Products.Remove(mapper.Map<Product>(product));
            context.SaveChanges();
        }
    }
}
