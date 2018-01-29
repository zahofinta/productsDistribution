using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.ProducerToProduct.Models
{
    public class ProducerToProductDTO
    {
        public int producer_to_product_id { get; set; }
        public int producer_id { get; set; }
        public int product_id { get; set; }

    }
}