using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class AnnouncementInfo
    { /*
        [Required(ErrorMessage = "Дата за доставка е задължително поле")]
        [Display(Name = "Дата за доставка :")]
        public DateTime arrive_date { get; set; }

        [Required(ErrorMessage = "Производител е задължително поле")]
        [Display(Name = "Производител :")]
        public IEnumerable<SelectListItem> producerNames = new List<SelectListItem>();


        public string selected_producerName { get; set; }

       public AddedProductsToAnnouncement AddedProductsToAnnouncement { get; set; }

        public List<AddedProductsToAnnouncement> addedProducts { get; set; }

        //public string selected_productName { get; set; }
        //[Required(ErrorMessage = "Максимално количество е задължително поле")]
        //[Display(Name = "Максимално количество :")]
        //public double quantity { get; set; }
        //[Required(ErrorMessage = "Цена е задължително поле")]
        //[Display(Name = "Цена :")]
        //public double price { get; set; }

        //[Required(ErrorMessage = "Продукт е задължително поле")]
        //[Display(Name = "Продукт :")]
        //public IEnumerable<SelectListItem> productNames = new List<SelectListItem>();
        /*public AnnouncementInfo()
        {
            AddedProductsToAnnouncement = new AddedProductsToAnnouncement();
        }
       */
        [Required(ErrorMessage = "Дата за доставка е задължително поле")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата за доставка :")]
        public DateTime arrive_date { get; set; }

        [Required(ErrorMessage ="Заглавие на обява е задължително поле")]

        public string title { get; set; }

        public ProductInfo firstProductInfo { get; set; }

        public List<ProductInfo> remainingProducts { get; set; }

        public AnnouncementInfo()
        {
            firstProductInfo = new ProductInfo();
            remainingProducts = new List<ProductInfo>();
        }
        
    }
}