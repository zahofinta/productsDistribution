using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Repositories
{
    public class AnnouncementToProductRepository : GenericEfRepository<AnnouncementToProduct>, IAnnouncementToProductRepository
    {

        public AnnouncementToProductRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}