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
        protected  override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //   modelBuilder.Entity<Category>().HasMany(i => i.Products)
            //.WithOptional(i => i.category)
            //.HasForeignKey(i => i.categoryId)
            //.WillCascadeOnDelete(false);
            //modelBuilder.Entity<User>();

            //  modelBuilder.Entity<Category>().HasOptional(x => x.parent_Category).WithMany(x => x.children).HasForeignKey(x => x.Category_parent_id).WillCascadeOnDelete(true);

            //modelBuilder.Entity<ProducerToProduct>().HasKey(x => new { x.producer_id, x.product_id});

            //modelBuilder.Entity<ProducerToProduct>()
            //    .HasOptional(producers => producers.producer)
            //    .WithMany(p => p.producers_to_products)
            //    .HasForeignKey(pc => pc.producer_id);

            //modelBuilder.Entity<ProducerToProduct>()
            //    .HasOptional(pc => pc.product)
            //    .WithMany(p => p.producers_to_products)
            //    .HasForeignKey(pc => pc.product_id);

           

            base.OnModelCreating(modelBuilder);

         

        
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