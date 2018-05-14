using ProductsDistribution.Core.Announcement.Models;
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

        public IQueryable<AnnouncementDTO> GetAllAnnouncements()
        {
            var announcements = _dbContext.Set<Announcement>();
            var all_announcements = from a in announcements

                                    select new AnnouncementDTO
                                    {
                                        announcement_id = a.announcement_id,
                                        arrive_date = a.arrive_date,

                                        publish_date = a.publish_date,
                                        status = a.status,
                                        title = a.title

                                    };
            
            return all_announcements;
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