using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Repositories
{
    public class SearchRepository : GenericEfRepository<Producer>,ISearchRepository
    {
        public SearchRepository(DbContext dbContext) : base(dbContext)
        {


        }

        public IQueryable<string> GetProducersAndProductsNames(string name)
        {
            var producers = this._dbSet;
            var products = _dbContext.Set<Product>();

            var searchResult = (from producer in producers
                                where producer.producer_name.Contains(name)
                                select producer.producer_name).Union(from product in products
                                                                     where product.product_name.Contains(name)
                                                                     select product.product_name);
            return searchResult;
        }
    }
}