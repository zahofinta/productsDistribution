using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductAnnouncementInputModel

    {
      //  public List<string> productNames { get; set; }

        public string selected_productName { get; set; }

        public double quantity { get; set; }

        public double price { get; set; }

        [Required(ErrorMessage = "Продукт е задължително поле")]
        [Display(Name = "Продукт :")]
        public IEnumerable<SelectListItem> productNames = new List<SelectListItem>();
    }
}