using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class ProducerViewModelFullDetails : ProducerViewModelShort

    {
        [Display(Name = "Телефонен номер :")]
        public string telephone_number { get; set; }

        [Display(Name = "Адрес :")]
        public string producer_address { get; set; }
    }
}