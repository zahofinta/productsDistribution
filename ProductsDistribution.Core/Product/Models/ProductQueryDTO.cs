﻿using ProductsDistribution.Core.QueryToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Product.Models
{
    public class ProductQueryDTO
    {
        ICollection<QueryToProductDTO> queries_to_products { get; set; }
    }
}