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
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductsDistribution.Data
{
    public class ProductsDistributionDBContext : IdentityDbContext<User>
    {
        public ProductsDistributionDBContext() :base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            
            //  modelBuilder.Entity<Category>().HasOptional(x => x.parent_Category).WithMany(x => x.children).HasForeignKey(x => x.Category_parent_id).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);

          
          //  modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Category>().HasMany(i => i.children)
            //.WithOptional(i => i.parent_Category)
            //.HasForeignKey(i => i.Category_parent_id)
            //.WillCascadeOnDelete(false);
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