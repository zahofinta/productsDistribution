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



        void AddNewProducerToProduct(ProducerToProductDTO producer);


        void Update(ProducerToProductDTO producer);

        void DeleteProduct(ProducerToProductDTO item);
    }
}