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

        [Required(ErrorMessage = "Производител е задължително поле")]
        [Display(Name = "Производител :")]
        public string selected_producerName { get; set; }


        [Required(ErrorMessage = "Продукт е задължително поле")]
        [Display(Name = "Продукт :")]
        public string selected_productName { get; set; }


        [Required(ErrorMessage = "Максимално количество е задължително поле")]
        [Min(1.0, ErrorMessage = "Въведете количество по-голямо от 0")]
        [Display(Name = "Максимално количество :")]
        [RegularExpression(@"-?\d+(?:\.\d+)?", ErrorMessage = "Полето максимално количество трябва да е положително число.Например 20.00")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Полето максимално количество трябва да е положително число.Например 20.00")]
        public double quantity { get; set; }


        [Required(ErrorMessage = "Цена е задължително поле")]
        [Min(0.1, ErrorMessage = "Въведете количество по-голямо от 0")]
        [Display(Name = "Цена :")]
        [RegularExpression(@"-?\d+(?:\.\d+)?", ErrorMessage = "Полето цена трябва да е положително число.Например 20.00")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Полето цена трябва да е положително число.Например 20.00")]
        public double price { get; set; }


        [Required(ErrorMessage = "Продукт е задължително поле")]
        [Display(Name = "Продукт :")]
        public IEnumerable<SelectListItem> productNames = new List<SelectListItem>();

    }
}