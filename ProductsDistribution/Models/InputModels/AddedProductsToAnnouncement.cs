using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class AddedProductsToAnnouncement
    {
        public string selected_productName { get; set; }
        [Required(ErrorMessage = "Максимално количество е задължително поле")]
        [Display(Name = "Максимално количество :")]
        public double quantity { get; set; }
        [Required(ErrorMessage = "Цена е задължително поле")]
        [Display(Name = "Цена :")]
        public double price { get; set; }

        [Required(ErrorMessage = "Продукт е задължително поле")]
        [Display(Name = "Продукт :")]
        public IEnumerable<SelectListItem> productNames = new List<SelectListItem>();
    }
}