using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Announcement.Models;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;

namespace ProductsDistribution.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        public readonly IRepository<Announcement> announcementRepository;


        public AnnouncementService(IRepository<Announcement> announcementRepository)

        {
            this.announcementRepository = announcementRepository;
            

        }

        public AnnouncementDTO MapAnnouncement(Announcement announcement)
        {
            return new AnnouncementDTO()
            {
                announcement_id = announcement.announcement_id,
                arrive_date = announcement.arrive_date,
                status = announcement.status,
                userId = announcement.userId

            };
        }
        public void AddNewAnnouncement(AnnouncementDTO announcement)
        {
            var announcementToAdd = new Announcement
            {
                announcement_id = announcement.announcement_id,
                arrive_date = announcement.arrive_date,
                isEnabled = true,
                status = 0,
                userId = announcement.userId
            };
            this.announcementRepository.Insert(announcementToAdd);

        }

        public void DeleteAnnouncement(AnnouncementDTO item)
        {
            var announcement = this.announcementRepository.Get(x => x.announcement_id == item.announcement_id);
            if(announcement==null)
            {
                
                    throw new ArgumentException("Cannot find producer with id: " + item.announcement_id);
                
            }
            this.announcementRepository.Delete(announcement);
        }

        public AnnouncementDTO GetById(int id)
        {
            var announcement = this.announcementRepository.Get(x => x.announcement_id == id);
            return this.MapAnnouncement(announcement);
        }

        public void Update(AnnouncementDTO announcement)
        {
            var announcementToUpdate = this.announcementRepository.Get(x => x.announcement_id == announcement.announcement_id);
            announcementToUpdate.arrive_date = announcement.arrive_date;
            announcementToUpdate.status = announcement.status;

            this.announcementRepository.Update(announcementToUpdate);
        }
    }
}