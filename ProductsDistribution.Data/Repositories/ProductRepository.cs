using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Product.Models;

namespace ProductsDistribution.Data.Repositories
{
    public class ProductRepository : GenericEfRepository<Product>,IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ProductBaseDTO> GetAllProductsByUserShort(string userId)
        {
            var products = this._dbSet;
            var all_products_by_user_short = from p in products
                                             where p.userId == userId
                                             select new ProductBaseDTO
                                             {
                                                 
                                                 product_name = p.product_name,
                                                 price = p.price,                                              
                                                 weight= p.weight,
                                                 volume = p.volume,
                                                 durability= p.durability,
                                                 rating = p.rating,
                                                 categoryId = p.categoryId
                                             };
            return all_products_by_user_short;
        }
    }
}