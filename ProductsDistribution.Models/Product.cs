using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public class Product { 
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public string product_description { get; set; }
        [Required]
        public string cut { get; set; }
        [Required]
        [Min(0.0, ErrorMessage = "Please enter weight greater than 0")]
        public float weight { get; set; }
        [Min(0.0, ErrorMessage = "Please enter volume greater than 0")]
        public float volume { get; set; }

        [DataType(DataType.Date)]
        public DateTime durability { get; set; }

        public string other { get; set; }
        public bool isEnabled { get; set; }
        public float rating { get; set; }
        [Required]
        public Category category { get; set; }

        public ICollection<ProducerToProduct> producers_to_products { get; set; }
        public ICollection<QueryToProduct> queries_to_products { get; set; }

        public ICollection<AnnouncementToProduct> announcements_to_products { get; set; }



    }
}