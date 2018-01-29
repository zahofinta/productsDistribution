using ProductsDistribution.Core.AnnouncementToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.InputModels
{
    public class AnnouncementInputModel
    {
        public int announcement_id { get; set; }
        public DateTime arrive_date { get; set; }
        public float max_quantity { get; set; }

        public int producer_id { get; set; }
        public int product_id { get; set; }

    }
}