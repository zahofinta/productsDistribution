using ProductsDistribution.Core.Category.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Product.Models
{
    public class ProductBaseDTO
    {
        public int product_id { get; set; }
        public string product_name { get; set; }

        public string product_description { get; set; }

        public double weight { get; set; }

        public double volume { get; set; }

        public DateTime durability { get; set; }

        public string unit { get; set; }

        public string other { get; set; }

        public double rating { get; set; }

        public int categoryId { get; set; }

        public string cut { get; set; }

        public double price { get; set; }

        public string userId { get; set; }

       // public string categoryName { get; set; }

    }
}