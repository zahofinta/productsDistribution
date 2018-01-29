using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class QueryToProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int query_to_product_id { get; set; }

        [Required]
        [Min(0.0, ErrorMessage = "Please enter quantity greater than 0")]
        public float quantity { get; set; }

        public int query_id { get; set; }
        public int product_id { get; set; }

        public Query query { get; set; }
        public Product product { get; set; }
    }
}