using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class ProducerInputModel
    {
  
        [Required]
        [Display(Name = "Име на производител :")]
        public string producer_name { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [Display(Name = "Телефонен номер :")]
        public string telephone_number { get; set; }
        [Required]
        [Display(Name = "Адрес :")]
        public string producer_address { get; set; }

        [Display(Name = "Имейл :")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string producer_email { get; set; }

        public List<string> selected_products { get; set; }

        [Display(Name = "Продукти :")]
        public IEnumerable<SelectListItem> products = new List<SelectListItem>();
    }
}