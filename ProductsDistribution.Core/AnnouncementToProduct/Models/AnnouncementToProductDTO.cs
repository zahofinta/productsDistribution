using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.AnnouncementToProduct.Models
{
    public class AnnouncementToProductDTO
    {
        public int announcement_to_product_id { get; set; }

        public double max_quantity { get; set; }

        public DateTime arrive_date { get; set; }

        public double price { get; set; }

        public int announcement_id { get; set; }

        public int product_id { get; set; }
    }
}