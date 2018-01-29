using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.InputModels
{
    public class QueryInputModel
    {
        public int query_id { get; set; }

        public float quantity { get; set; }

        public int product_id { get; set; }

    }
}