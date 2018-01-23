using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class Query
    {
        [Key]
        public int query_id { get; set; }
        public User user { get; set; }

        public ICollection<QueryToProduct> queries_to_products { get; set; }

    }
}