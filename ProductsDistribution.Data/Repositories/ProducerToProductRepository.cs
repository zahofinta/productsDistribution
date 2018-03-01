using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.ProducerToProduct.Models;
using System.Data.Entity;

namespace ProductsDistribution.Data.Repositories
{
    public class ProducerToProductRepository : GenericEfRepository<ProducerToProduct>,IProducerToProductRepository
    { 
    public ProducerToProductRepository(DbContext dbContext) : base(dbContext)
        {


        }
       

     /*public ProducerToProduct GetByProductId(int id)
        {
            var producersToProducts = this._dbSet;
            var prodToproducts = (from p in producersToProducts
                                 where p.product_id == id
                                 select new ProducerToProduct
                                 {
                                     producer_id = p.producer_id,
                                     product_id = id,
  
                                 }).First();
            return prodToproducts;
        }
        */
    }
}