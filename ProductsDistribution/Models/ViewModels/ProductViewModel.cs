using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProductViewModelShort
    {
         
        public string product_name { get; set; }
       
        public double weight { get; set; }
        
        public double volume { get; set; }

        public DateTime durability { get; set; }


        public double price { get; set; }

        public float rating { get; set; }

        public string category { get; set; }
    }
}