using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductInfo
    {
        [Required(ErrorMessage = "Производител е задължително поле")]
        [Display(Name = "Производител :")]
        public IEnumerable<SelectListItem> producerNames = new List<SelectListItem>();


        public string selected_producerName { get; set; }

        public string selected_productName { get; set; }
        [Required(ErrorMessage = "Максимално количество е задължително поле")]
        [Display(Name = "Максимално количество :")]
        [Min(1, ErrorMessage = "Въведете количество по-голямо от 0")]
        public double quantity { get; set; }
        [Required(ErrorMessage = "Цена е задължително поле")]
        [Display(Name = "Цена :")]
        public double price { get; set; }

        [Required(ErrorMessage = "Продукт е задължително поле")]
        [Display(Name = "Продукт :")]
        public IEnumerable<SelectListItem> productNames = new List<SelectListItem>();

    }
}