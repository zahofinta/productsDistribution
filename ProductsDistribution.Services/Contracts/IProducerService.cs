using ProductsDistribution.Core.Producer.Models;
using ProductsDistribution.Models;
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

        int GetProducerIdByName(string producerName);
         int AddNewProducer(ProducerDTO producer);

        ProducerDTO GetProducerByIdAndUserId(int id, string userId);

        List<string> GetProducerNamesByUserId(string userId);

        List<string> GetProductNamesByProducerNameAndUserId(string producerName, string userId);


        void Update(ProducerDTO producer);

        void DeleteProducer(ProducerDTO item);
    }
}