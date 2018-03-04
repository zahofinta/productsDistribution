using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Producer.Models;
using System.Data.Entity;

namespace ProductsDistribution.Data.Repositories
{
    public class ProducerRepository : GenericEfRepository<Producer>, IProducerRepository
    {

        public ProducerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ProducerDTO> GetAllProducersByUserShort(string userId)
        {
            var producers = this._dbSet;
            var all_products_by_user_short = from p in producers
                                             where p.userId == userId
                                             select new ProducerDTO
                                             {
                                                 producer_address = p.producer_address,
                                                 producer_id = p.producer_id,
                                                 producer_email = p.producer_email,
                                                 producer_name = p.producer_name,
                                                 rating = p.rating,
                                                 telephone_number = p.telephone_number

                                             };
            return all_products_by_user_short;
        }

        public int GetProducerIdByName(string producerName)
        {
            var producers = this._dbSet;
            int producerId = producers.Where(x => x.producer_name == producerName).First().producer_id;

            return producerId;


        }

        private Producer ChangeState(Producer entity, EntityState state)
        {
            var entry = this._dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._dbSet.Add(entity);
            }

            entry.State = state;
            return entity;
        }
        new public int Insert(Producer entity)
        {
            this.ChangeState(entity, EntityState.Added);
            _dbContext.SaveChanges();
            int producerId = entity.producer_id;

            return producerId;
        }

        public ProducerDTO GetProducerByIdAndUserId(int id, string userId)
        {
            var producers = this._dbSet;

            var producerToEdit = (from p in producers
                                  where p.producer_id == id && p.userId.Equals(userId)
                                  select new ProducerDTO
                                  {
                                      producer_id = p.producer_id,
                                      producer_name = p.producer_name,                                 
                                      userId = p.userId,
                                      producer_address = p.producer_address,
                                      producer_email = p.producer_email,
                                      rating = p.rating,
                                      telephone_number = p.telephone_number
                                  }).FirstOrDefault();

            return producerToEdit;
        }

        public List<string> GetProducerNamesByUserId(string userId)
        {
            var producers = this._dbSet;
            var producerNamesByUserId = producers.Where(x => x.userId == userId).Select(x => x.producer_name).ToList();

            return producerNamesByUserId;
        }

        public List<string> GetProductNamesByProducerNameAndUserId(string producerName, string userId)
        { 

            var producers = this._dbSet;
            var producerToProducts = _dbContext.Set<ProducerToProduct>();
            var products = _dbContext.Set<Product>();
            var productNamesByProducerNameAndUserId = (from producer in producers
                                                       join ptp in producerToProducts on producer.producer_id equals ptp.producer_id
                                                       join product in products on ptp.product_id equals product.product_id
                                                       where producerName == producer.producer_name && userId == producer.userId
                                                       select product.product_name).ToList();
            return productNamesByProducerNameAndUserId;

            
        }
    }
}