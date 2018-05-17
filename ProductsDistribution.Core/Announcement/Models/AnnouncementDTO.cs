using ProductsDistribution.Core.AnnouncementToProduct.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Announcement.Models
{
    public class AnnouncementDTO
    {
        public int announcement_id { get; set; }
   
       // public string arrive_date { get; set; }
        public DateTime? arrive_date { get; set; }

        public DateTime publish_date { get; set; }
        public string title { get; set; }
        public Status status { get; set; }

        public string userId { get; set; }

        public ICollection<AnnouncementToProductDTO> announcements_to_products { get; set; }
    }
}