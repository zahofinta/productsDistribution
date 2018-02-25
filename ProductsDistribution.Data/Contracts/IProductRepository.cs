using ProductsDistribution.Core.Product.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductBaseDTO> GetAllProductsByUserShort(string userId);

        ProductBaseDTO GetProductByIdAndUserId(int id, string userId);

        bool isInProducts(int id);

        List<string> GetListOfProductNamesByUserId(string userId);

        int GetProductIdByName(string productName,string userId);

        List<string> GetAllSelectedProductNamesByUserId(string userId,int producerId);
    }
}