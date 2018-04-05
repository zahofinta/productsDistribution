using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProductViewModelShort
    {

        public int product_id { get; set; }
        [Display(Name = "Име на продукт :")]
        public string product_name { get; set; }
        [Display(Name = "Трайност :")]
        public DateTime durability { get; set; }
        //[Display(Name = "Цена :")]
        //public double price { get; set; }
        [Display(Name = "Категория :")]
        public string category { get; set; }

        public string userId { get; set; }

        public ProductViewModelShort()
        {

        }
    }
}