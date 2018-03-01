using ProductsDistribution.Core.Producer.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Contracts
{
    public interface IProducerRepository : IRepository<Producer>

    {
        IEnumerable<ProducerDTO> GetAllProducersByUserShort(string userId);

        int GetProducerIdByName(string producerName);

        ProducerDTO GetProducerByIdAndUserId(int id, string userId);

        new int Insert(Producer entity);
       // int Insert(Producer entity);
    }
}