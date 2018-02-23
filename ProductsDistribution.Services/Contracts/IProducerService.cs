using ProductsDistribution.Core.Producer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface IProducerService
    {
        ProducerDTO GetById(int id);


        IEnumerable<ProducerDTO> GetAllProducersByUserShort(string userId);
        void AddNewProducer(ProducerDTO producer);

      
        void Update(ProducerDTO producer);

        void DeleteProduct(ProducerDTO item);
    }
}