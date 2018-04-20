using ProductsDistribution.Core.Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IAnnouncementService

 { 
    AnnouncementDTO GetById(int id);


    int AddNewAnnouncement(AnnouncementDTO announcement);


    void Update(AnnouncementDTO announcement);

    void DeleteAnnouncement(AnnouncementDTO item);
}
}