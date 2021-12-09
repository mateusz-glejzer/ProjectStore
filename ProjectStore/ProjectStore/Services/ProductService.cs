using AutoMapper;
using ProjectStore.Entities;
using ProjectStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStore.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext context;
        private readonly IMapper mapper;

        public ProductService(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string ProductAdd(ProductDto productDto)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product product = mapper.Map<Product>(productDto);
                context.Products.Add(product);
                context.SaveChanges();
                transaction.Commit();
                return $"Product {product.Name} added";
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return $"Error: {ex.Message}";
            }
        }

        public string ProductDelete(int id)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                transaction.Commit();
                return $"Product {id} deleted";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Error: {ex.Message}";
            }
        }

        public List<ProductDto> ProductGet()
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                List<ProductDto> retList = mapper.Map<List<ProductDto>>( context.Products.ToList() ); 

                return retList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }

        public string ProductUpdate(ProductDto productDto)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product product = mapper.Map<Product>(productDto);
                context.Products.Update(product);
                context.SaveChanges();
                transaction.Commit();
                return $"Product {product.Name} updated";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Error: {ex.Message}";
            }
        }
    }
}
