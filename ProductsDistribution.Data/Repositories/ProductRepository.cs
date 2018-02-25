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

        public List<string> GetAllSelectedProductNamesByUserId(string userId,int producerId)
        {
            var producerToProducts = _dbContext.Set<ProducerToProduct>();
            var products = this._dbSet;
            var producers = _dbContext.Set<Producer>();
            var allSelectedProductNamesByUser = (from p in products
                                                 join ptp in producerToProducts on p.product_id equals ptp.product_id
                                                 where p.userId == userId && ptp.producer_id == producerId
                                                 select p.product_name).ToList();

            return allSelectedProductNamesByUser;
        }

        public List<string> GetListOfProductNamesByUserId(string userId)
        {
            var products = this._dbSet;
            List<string> product_names_by_userid = products.Where(x => x.userId == userId).Select(x => x.product_name).ToList();
            return product_names_by_userid;
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

        public int GetProductIdByName(string productName,string userId)
        {
            var products = this._dbSet;
            return products.SingleOrDefault(x => x.userId == userId && x.product_name == productName).product_id;
        }

      

        public  bool isInProducts(int id)
        {
            var products = this._dbSet;
            bool result = products.Any(x => x.categoryId == id);

            return result;

        }
    }
}