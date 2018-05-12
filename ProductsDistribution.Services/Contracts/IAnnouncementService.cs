using ProductsDistribution.Core.Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IAnnouncementService

 {
        //List<Announcement> GetAllAnnouncements();
        AnnouncementDTO GetById(int id);

        IEnumerable<AnnouncementDTO> GetAllAnnouncements();
    int AddNewAnnouncement(AnnouncementDTO announcement);


    void Update(AnnouncementDTO announcement);

    void DeleteAnnouncement(AnnouncementDTO item);
}
}