using ProductsDistribution.Core.ProducerToProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IProducerToProductService
    {
        ProducerToProductDTO GetById(int id);

        ProducerToProductDTO GetByProductId(int id);

        void AddNewProducerToProduct(ProducerToProductDTO producer);

      //  IEnumerable<ProducerToProductDTO> GetAllProducersToProducts(int id);
        void Update(ProducerToProductDTO producer);

        void DeleteProducerToProduct(ProducerToProductDTO item);
    }
}