using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProductViewModel
    {
        public int product_id { get; set; }  
        public string product_name { get; set; }
       
        public string product_description { get; set; }
        
        public string cut { get; set; }
     
        public float weight { get; set; }
        
        public float volume { get; set; }

        public DateTime durability { get; set; }

        public string other { get; set; }

        public float rating { get; set; }
    }
}