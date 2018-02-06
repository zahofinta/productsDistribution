﻿using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Product.Models;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;

namespace ProductsDistribution.Services
{

    public class ProductService : IProductService

    {
        public readonly IRepository<Product> productRepository;
        public readonly IRepository<Category> categoryRepository;


        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)

        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;

        }

        public ProductBaseDTO MapProduct(Product product)
        {
            return new ProductBaseDTO()
            {
                product_id = product.product_id,
                product_name = product.product_name,
                product_description = product.product_description,
                cut = product.cut,
                weight = product.weight,
                volume = product.volume,
                durability = product.durability,
                other = product.other,
                rating = product.rating,
                categoryId = product.category.category_id,
                price = product.price
                

            };
        }

        public void AddNewProduct(ProductBaseDTO product)
        {
            var productToAdd = new Product
            {
                product_id = product.product_id,
                product_name = product.product_name,
                product_description = product.product_description,
                cut = product.cut,
                weight = product.weight,
                durability = product.durability,
                volume = product.volume,
                other = product.other,
                categoryId = product.categoryId,
                rating = 0.0,
                isEnabled = true,
                price = product.price
            };
            this.productRepository.Insert(productToAdd);
        }

        public void DeleteProduct(ProductBaseDTO item)
        {
            var product = this.productRepository.Get(x => x.product_id == item.product_id);

            if (item == null)
            {
                throw new ArgumentException("Cannot find product with id: " + item.product_id);
            }

            this.productRepository.Delete(product);
        }

        public ProductBaseDTO GetById(int id)
        {
            var product = this.productRepository.Get(x => x.product_id == id);
            return this.MapProduct(product);
        }

        public void Update(ProductBaseDTO product)
        {
            var productToUpdate = this.productRepository.Get(x=>x.product_id == product.product_id);

            productToUpdate.product_name =product.product_name;
            productToUpdate.product_description = product.product_description;
            productToUpdate.cut = product.cut;
            productToUpdate.weight = product.weight;
            productToUpdate.durability = product.durability;
            productToUpdate.volume = product.volume;
            productToUpdate.other = product.other;
            productToUpdate.category.category_id = product.categoryId;
            productToUpdate.price = product.price;

            this.productRepository.Update(productToUpdate);
        }

    }
}
