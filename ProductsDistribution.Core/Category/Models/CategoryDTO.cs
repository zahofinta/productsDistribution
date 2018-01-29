using ProductsDistribution.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace ProductsDistribution.Core.Category.Models
{
    public class CategoryDTO
    { 

    public int category_id { get; set; }

    public string category_name { get; set; }
    
    public string category_description { get; set; }

    
    public int? CategoryDTO_parent_id { get; set; }

    
    
    

    

}
}