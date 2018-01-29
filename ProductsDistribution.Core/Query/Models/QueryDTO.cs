using ProductsDistribution.Core.QueryToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Query.Models
{
    public class QueryDTO
    {
        public int query_id { get; set; }
        public string userId { get; set; }
        public ICollection<QueryToProductDTO> queries_to_products { get; set; }

    }
}