using ProductsDistribution.Core.Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Contracts
{
    public interface ISearchRepository
    {
        IQueryable<String> GetProducersAndProductsNames(string name);

        IQueryable<AnnouncementDTO> GetAllAnnouncements();
    }
}