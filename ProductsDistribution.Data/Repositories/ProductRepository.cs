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
                                                  product_id = p.product_id,
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

       public ProductBaseDTO GetProductByIdAndUserId(int id, string userId)
        {
            var products = this._dbSet;
            var get_product_id_by_id_and_userId = (from p in products
                                                  where p.product_id == id && p.userId.Equals(userId)
                                                  select new ProductBaseDTO
                                                  {
                                                      product_id = p.product_id,
                                                      product_name = p.product_name,
                                                      price = p.price,
                                                      durability = p.durability,
                                                      cut = p.cut,
                                                      product_description = p.product_description,
                                                      other = p.other,
                                                      weight = p.weight,
                                                      rating = p.rating,
                                                      userId = p.userId,
                                                      volume = p.volume,
                                                      categoryId = p.categoryId
                                                  }).FirstOrDefault();
            return get_product_id_by_id_and_userId;
        }

      public  bool isInProducts(int id)
        {
            var products = this._dbSet;
            bool result = products.Any(x => x.product_id == id);

            return result;

        }
    }
}