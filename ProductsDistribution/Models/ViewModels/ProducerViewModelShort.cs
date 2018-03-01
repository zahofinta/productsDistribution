using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProducerViewModelShort
    {
        public int producer_id { get; set; }

        [Display(Name = "Име на продукт :")]
        public string producer_name { get; set; }

        // public string telephone_number { get; set; }

        //public string producer_address { get; set; }

        [Display(Name = "Имейл :")]
        public string producer_email { get; set; }

        [Display(Name = "Продукти :")]
        public List<string> producer_products { get; set; }

        [Display(Name = "Рейтинг :")]
        public double rating { get; set; }

        public string userId { get; set; }
        //<string> producer_products {get;set;}

        public ProducerViewModelShort()
        {

        }

        public ProducerViewModelShort(List<string> producer_products)
        {
            this.producer_products = producer_products;
        }
    }
}