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

        public IEnumerable<ProductBaseDTO> GetAllProductsByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}