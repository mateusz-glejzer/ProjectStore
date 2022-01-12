﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectStore.Authorization;
using ProjectStore.Entities;
using ProjectStore.Exceptions;
using ProjectStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectStore.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext context;
        private readonly IMapper mapper;
        private readonly IAuthorizationService authorizationService;

        public ProductService(StoreDbContext context, IMapper mapper, IAuthorizationService authorizationService)
        {
            this.context = context;
            this.mapper = mapper;
            this.authorizationService = authorizationService;
        }

        public void ProductAdd(ProductDto productDto, int userId)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product product = mapper.Map<Product>(productDto);
                product.CreatedByUserId = userId;
                context.Products.Add(product);
                context.SaveChanges();
                transaction.Commit();
                //return $"Product {product.Name} added";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                //return $"Error: {ex.Message}";
            }
        }

        public string ProductDelete(int id, ClaimsPrincipal user)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product product = context.Products.Find(id);
                var authorizationResult = authorizationService.AuthorizeAsync(user, product, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;
                if (!authorizationResult.Succeeded)
                {
                    throw new ForbidException("access denied");
                }
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
                List<ProductDto> retList = mapper.Map<List<ProductDto>>(context.Products.ToList());

                return retList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }
        public  ProductDto ProductGetById(int id)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                Product entity = context.Products.FirstOrDefault(x => x.Id == id);
                ProductDto product = mapper.Map<ProductDto>(entity); 

                return product;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }

        public string ProductUpdate(int ProductId, ProductDto productDto, ClaimsPrincipal user)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var productInDb = context
                    .Products
                    .FirstOrDefault(p => p.Id == ProductId);
                if (productInDb is null)
                {
                    throw new NotFoundException("Product not found");
                }

                // Product product = mapper.Map<Product>(productDto);
                var authorizationResult = authorizationService.AuthorizeAsync(user, productInDb, new ResourceOperationRequirement(ResourceOperation.Update)).Result;
                if (!authorizationResult.Succeeded)
                {
                    throw new ForbidException("access denied");
                }
                productInDb.Name = productDto.Name;
                productInDb.Description = productDto.Description;
                productInDb.Image = productDto.Image;
                productInDb.Price = productDto.Price;

                context.Products.Update(productInDb);
                context.SaveChanges();
                transaction.Commit();
                return $"Product {productInDb.Name} updated";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Error: {ex.Message}";
            }
        }
    }
}
