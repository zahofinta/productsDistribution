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

        public float weight { get; set; }

        public float volume { get; set; }

        public DateTime durability { get; set; }

        public string other { get; set; }

        public float rating { get; set; }

        public int categoryId { get; set; }

        public string categoryName { get; set; }

    }
}