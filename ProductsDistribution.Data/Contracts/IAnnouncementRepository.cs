using ProductsDistribution.Core.Announcement.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Contracts
{
    public interface IAnnouncementRepository : IRepository<Announcement>

    {
        IEnumerable<AnnouncementDTO> GetAllAnnouncements();
    }
}