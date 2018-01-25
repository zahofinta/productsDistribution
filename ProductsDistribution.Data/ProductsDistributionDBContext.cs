using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductsDistribution.Data
{
    public class ProductsDistributionDBContext : IdentityDbContext<User>
    {
        public ProductsDistributionDBContext() :base("DefaultConnection")
        {

        }
        static ProductsDistributionDBContext()
        {
            Database.SetInitializer<ProductsDistributionDBContext>(new CreateDatabaseIfNotExists<ProductsDistributionDBContext>());
        }

        DbSet<Producer> Producers { get; set; }
        DbSet<Product> Products { get; set; }

        DbSet<Query> Queries { get; set; }

        DbSet<Category> Categories { get; set; }
        DbSet<Announcement> Announcements { get; set; }
        DbSet<ProducerToProduct>  ProducersToProducts { get; set; }
        DbSet<QueryToProduct> QueriesToProducts { get; set; }
        DbSet<AnnouncementToProduct> AnnouncementsToProducts { get; set; }
      // override public IEnumerable<object> Users { get; set; }

        public static ProductsDistributionDBContext Create()
        {
            return new ProductsDistributionDBContext();
        }
    }
}