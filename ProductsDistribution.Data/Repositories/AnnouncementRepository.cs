using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Announcement.Models;

namespace ProductsDistribution.Data.Repositories
{
    public class AnnouncementRepository : GenericEfRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(DbContext dbContext) : base(dbContext)
        {

        }


        public AnnouncementDTO MapAnnouncement(Announcement announcement)
        {
            return new AnnouncementDTO()
            {
                announcement_id = announcement.announcement_id,
                arrive_date = announcement.arrive_date,
                title = announcement.title,
                status = announcement.status,
                userId = announcement.userId

            };
        }

        public IEnumerable<AnnouncementDTO> GetAllAnnouncements()
        {
            var announcements = this._dbSet;
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
    }
}