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
    { 

        [Required]

        [DisplayFormat(DataFormatString= "{0:dd/MM/yy}", ApplyFormatInEditMode= true)]
     
        [Display(Name = "Дата на доставка  :")]
        public DateTime? arrive_date { get; set; }

        [Required(ErrorMessage ="Заглавие на обява е задължително поле")]
        [Display(Name = "Заглавие на обява  :")]
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