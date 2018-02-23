using ProductsDistribution.Core.ProducerToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Producer.Models
{
    public class ProducerDTO
    {
        public int producer_id { get; set; }

        public string producer_name { get; set; }

        public string telephone_number { get; set; }
        public string producer_address { get; set; }
        public string producer_email { get; set; }
        public string userId { get; set; }
        public double rating { get; set; }
       // public ICollection<ProducerToProductDTO> producers_to_products { get; set; }
    }
}