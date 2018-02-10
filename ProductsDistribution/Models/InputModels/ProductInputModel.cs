using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductInputModel

    {
        [Required]
        public string product_name { get; set; }
        [Required]
        public string product_description { get; set; }
        [Required]
        public string cut { get; set; }
        [Required]
        [Min(0.0, ErrorMessage = "Please enter weight greater than 0")]
        public double weight { get; set; }
        [Min(0.0, ErrorMessage = "Please enter volume greater than 0")]
        public double volume { get; set; }
        [Required]
        [Min(0.0, ErrorMessage = "Please enter price greater than 0")]
        public double price { get; set; }
        [DataType(DataType.Date)]
        public DateTime durability { get; set; }

        public string other { get; set; }

        public string selected_ParentCategory{ get; set; }

        public string selected_ChildCategory { get; set; }

        

        [Display(Name = "Kатегория :")]
        public IEnumerable<SelectListItem> parent_categories = new List<SelectListItem>();

        [Display(Name = "Подкатегория :")]
        public IEnumerable<SelectListItem> child_categories = new List<SelectListItem>();


    }
}