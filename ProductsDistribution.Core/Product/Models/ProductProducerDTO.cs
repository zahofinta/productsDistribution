using ProductsDistribution.Core.AnnouncementToProduct.Models;
using ProductsDistribution.Core.ProducerToProduct.Models;
using ProductsDistribution.Core.QueryToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Core.Product.Models
{
    public class ProductProducerDTO : ProductBaseDTO
    {
        ICollection<ProducerToProductDTO> producers_to_products { get; set; }
  

       
    }
}