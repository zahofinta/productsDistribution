using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class CategoryInputEditModel
    {
        public int category_id { get; set; }
        [Required]
        [Display(Name = "Име на категория :")]
        public string category_name { get; set; }
        [Required]
        [Display(Name = "Описание :")]
        public string category_description { get; set; }

        public string selectedCategory { get; set; }

        //public int? Category_parent_id { get; set; }
        [Display(Name = "Подкатегория :")]
        public IEnumerable<SelectListItem> categories { get; set; }
    }
}