using ProductsDistribution.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IProductService
    {
        ProductBaseDTO GetById(int id);

      
        void AddNewProduct(ProductBaseDTO product);

        
        void Update(ProductBaseDTO product);

        void DeleteProduct(ProductBaseDTO item);

        IEnumerable<ProductBaseDTO> GetAllProductsByUser(string userId);

        ProductBaseDTO GetProductByIdAndUserId(int id,string userId);
    }
}