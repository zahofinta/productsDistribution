using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class AnnouncementToProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int announcement_to_product_id{get;set;}

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime arrive_date { get; set; }
        [Required]
        [Min(0.0, ErrorMessage = "Въведете  максимално количество по-голямо от 0")]


        public double max_quantity { get; set; }

        [Required]
        [Min(0.0, ErrorMessage = "Въведете цена по-голяма от 0")]

        public double price { get; set; }

        public int announcement_id { get; set; }

        public int product_id { get; set; }

        public Announcement announcement { get; set; }
        public Product product { get; set; }

    
    }
}