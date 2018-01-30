using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsDistribution.Services.Contracts;
using Newtonsoft.Json.Linq;

namespace ProductsDistribution.Models.InputModels
{
    public class CategoryInputModel
    {


        [Required]
        public string category_name { get; set; }
        [Required]
        public string category_description { get; set; }

        public string selectedCategory { get; set; }

        //public int? Category_parent_id { get; set; }
       
        public IEnumerable<SelectListItem> categories { get;set; }
    }
}