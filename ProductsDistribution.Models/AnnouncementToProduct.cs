using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class AnnouncementToProduct
    {
        [Key]
        public int announcement_to_product_id{get;set;}

        [Required]
        [Min(0.0, ErrorMessage = "Please enter max quantity greater than 0")]
       

        public float max_quantity { get; set; }

        public int announcement_id { get; set; }

        public int product_id { get; set; }

        public Announcement announcement { get; set; }
        public Product product { get; set; }

    
    }
}