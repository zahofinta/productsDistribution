using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductAnnouncementInputModel

    {
        public List<string> productNames { get; set; }

        public string selected_productName { get; set; }

        public double quantity { get; set; }

        public double price { get; set; }
    }
}