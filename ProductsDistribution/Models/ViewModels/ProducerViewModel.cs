using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProducerViewModel
    {
        public int producer_id { get; set; }
        public string producer_name { get; set; }

        public string telephone_number { get; set; }
       
        public string producer_address { get; set; }

        
        public string producer_email { get; set; }

        public float rating { get; set; }
    }
}