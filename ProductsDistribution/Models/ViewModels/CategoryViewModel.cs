using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class CategoryViewModel
    {

        
        public int category_id { get; set; }
        public string category_name { get; set; }

        public List<string> sub_categories { get; set; }

        public CategoryViewModel(List<string> sub_categories)
        {
            this.sub_categories = sub_categories;
        }

        public CategoryViewModel()
        {

        }
      
    }
}