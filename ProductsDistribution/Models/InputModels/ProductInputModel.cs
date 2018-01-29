using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductInputModel

    {
 
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

        public int categoryId { get; set; }
    }
}