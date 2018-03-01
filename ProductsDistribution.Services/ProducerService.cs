using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Producer.Models;
using ProductsDistribution.Models;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Data.Repositories;

namespace ProductsDistribution.Services
{
    public class ProducerService : IProducerService
    {

        public readonly IRepository<Producer> producerRepository;
        public readonly ProducerRepository ProducerRepository;

        public ProducerService(IRepository<Producer> producerRepository, ProducerRepository ProducerRepository)

        {
            this.producerRepository = producerRepository;
            this.ProducerRepository = ProducerRepository;
        }

        public ProducerDTO MapProducer(Producer producer)
        {
            return new ProducerDTO()
            {
                producer_id = producer.producer_id,
                producer_name = producer.producer_name,
                producer_address = producer.producer_address,
                producer_email = producer.producer_email,
                userId = producer.userId,
                rating = producer.rating,
                telephone_number = producer.telephone_number

                
            };
        }
       public int AddNewProducer(ProducerDTO producer)
        {
            var producerToAdd = new Producer
            {
                producer_id = producer.producer_id,
                producer_email = producer.producer_email,
                producer_address = producer.producer_address,
                producer_name = producer.producer_name,
                userId = producer.userId,
                rating = 0.0,
                isEnabled = true,
                telephone_number = producer.telephone_number,
                
             
            };
            //string producerToAddId = producerToAdd.producer_name;
            this.producerRepository.Insert(producerToAdd);

            int addedProducerId = producerToAdd.producer_id;

            return addedProducerId;
  
        } 

        public void DeleteProducer(ProducerDTO item)
        {
            var producer = this.producerRepository.Get(x => x.producer_id == item.producer_id);

            if (item == null)
            {
                throw new ArgumentException("Cannot find producer with id: " + item.producer_id);
            }

            this.producerRepository.Delete(producer);
        }

        public ProducerDTO GetById(int id)
        {
            var producer = this.producerRepository.Get(x => x.producer_id == id);
            return this.MapProducer(producer);
        }

        public void Update(ProducerDTO producer)
        {
            var producerToUpdate = this.producerRepository.Get(x => x.producer_id == producer.producer_id);

            producerToUpdate.producer_id = producer.producer_id;
            producerToUpdate.producer_name = producer.producer_name;
            producerToUpdate.producer_email = producer.producer_email;
            producerToUpdate.producer_address = producer.producer_address;
            producer.telephone_number = producer.telephone_number;

            this.producerRepository.Update(producerToUpdate);
        }

        public IEnumerable<ProducerDTO> GetAllProducersByUserShort(string userId)
        {
            return this.ProducerRepository.GetAllProducersByUserShort(userId);
        }

        public int GetProducerIdByName(string producerName)
        {
            return this.ProducerRepository.GetProducerIdByName(producerName);
        }

        public ProducerDTO GetProducerByIdAndUserId(int id, string userId)
        {
            return this.ProducerRepository.GetProducerByIdAndUserId(id, userId);
        }
    }
}