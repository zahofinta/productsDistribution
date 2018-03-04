using ProductsDistribution.Core.AnnouncementToProduct.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class AnnouncementInputModel
    {

        public DateTime arrive_date { get; set; }

        [Required(ErrorMessage = "Производител е задължително поле")]
        [Display(Name = "Производител :")]
        public IEnumerable<SelectListItem> producerNames = new List<SelectListItem>();


        public string selected_producerName { get; set; }
       

        public List<ProductAnnouncementInputModel> product_properties {get;set;}



    }
}