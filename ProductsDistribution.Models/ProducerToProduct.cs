using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class ProducerToProduct
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int producer_to_product_id { get; set; }
        public int producer_id { get; set; }
        public int product_id { get; set; }

        public Producer producer { get; set; }
        public Product product { get; set; }


    }
}