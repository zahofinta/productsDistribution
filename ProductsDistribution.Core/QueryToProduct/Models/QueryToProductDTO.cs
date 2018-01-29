using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.QueryToProduct.Models
{
    public class QueryToProductDTO
    {
        public int query_to_product_id { get; set; }

        public float quantity { get; set; }

        public int query_id { get; set; }
        public int product_id { get; set; }
    }
}