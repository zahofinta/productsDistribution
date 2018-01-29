using ProductsDistribution.Core.AnnouncementToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Product.Models
{
    public class ProductAnnouncementDTO
    {
        ICollection<AnnouncementToProductDTO> announcements_to_products { get; set; }
    }
}