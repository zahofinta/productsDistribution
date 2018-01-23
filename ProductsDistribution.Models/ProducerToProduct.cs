using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class ProducerToProduct
    {
        [Key]
        public int producer_to_product_id { get; set; }
        public int producer_id { get; set; }
        public int product_id { get; set; }

        public Producer producer { get; set; }
        public Product product { get; set; }


    }
}