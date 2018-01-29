using ProductsDistribution.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Category.Models
{
    public class CategoryFullDTO : CategoryDTO
    {
        public CategoryDTO parent_Category { get; set; }

        public ICollection<CategoryDTO> children { get; set; }

        public ICollection<ProductBaseDTO> products;
    }
}