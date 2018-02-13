using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProductViewModelFullDetails : ProductViewModelShort
    { 
       [Display(Name = "Описание на продукта :")]
        public string product_description { get; set; }
        [Display(Name = "Разфасовка :")]

        public string cut { get; set; }
        [Display(Name = "Допълнение към описанието :")]
        public string other { get; set; }
        [Display(Name = "Тегло :")]
        public double weight { get; set; }
        [Display(Name = "Обем :")]
        public double volume { get; set; }
        [Display(Name = "Рейтинг :")]
        public double rating { get; set; }

    }
}