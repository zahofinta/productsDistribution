using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Repositories
{
    public class AnnouncementRepository : GenericEfRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}