using ProductsDistribution.Core.AnnouncementToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IAnnouncementToProductService
    {
        AnnouncementToProductDTO GetById(int id);


        void AddNewAnnouncementToProduct(AnnouncementToProductDTO announcementToProduct);


        void Update(AnnouncementToProductDTO announcementToProduct);

        void DeleteAnnouncementToProduct(AnnouncementToProductDTO item);
    }
}