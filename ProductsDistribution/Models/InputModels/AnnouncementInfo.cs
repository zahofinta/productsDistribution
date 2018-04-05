using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class AnnouncementInfo
    {
        [Required(ErrorMessage = "Дата за доставка е задължително поле")]
        [Display(Name = "Дата за доставка :")]
        public DateTime arrive_date { get; set; }

        [Required(ErrorMessage = "Производител е задължително поле")]
        [Display(Name = "Производител :")]
        public IEnumerable<SelectListItem> producerNames = new List<SelectListItem>();


        public string selected_producerName { get; set; }

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

        public bool isDeleted { get; set; }

        public int Index { get; set; }
    }
}