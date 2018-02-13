using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProductViewModelShort
    {

        public int product_id { get; set; }
        public string product_name { get; set; }
       
        public double weight { get; set; }
        
        public double volume { get; set; }

        public DateTime durability { get; set; }


        public double price { get; set; }

        public double rating { get; set; }

        public string category { get; set; }

        public string userId { get; set; }

        public ProductViewModelShort()
        {

        }
    }
}