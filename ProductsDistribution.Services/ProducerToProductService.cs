using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.ProducerToProduct.Models;
using ProductsDistribution.Models;
using ProductsDistribution.Data.Contracts;

namespace ProductsDistribution.Services
{
    public class ProducerToProductService : IProducerToProductService
    {

        public readonly IRepository<ProducerToProduct> producerToProductRepository;
     


        public ProducerToProductService(IRepository<ProducerToProduct> producerToProductRepository)

        {
            this.producerToProductRepository = producerToProductRepository;
            

        }

        public ProducerToProductDTO MapProducerToProduct(ProducerToProduct producerToProduct)
        {
            return new ProducerToProductDTO()
            {
                producer_id = producerToProduct.producer_id,
                product_id = producerToProduct.product_id,
                producer_to_product_id = producerToProduct.producer_to_product_id
 
            };
        }

        public ProducerToProduct MapProducerToProductDTOToProducerToProduct(ProducerToProductDTO producerToProduct)
        {
            return new ProducerToProduct()
            {
                producer_id = producerToProduct.producer_id,
                product_id = producerToProduct.product_id,
                producer_to_product_id = producerToProduct.producer_to_product_id
               

            };
        }
        public void AddNewProducerToProduct(ProducerToProductDTO producerToProduct)
        {
            var producerToProductToAdd = new ProducerToProduct
            {
                producer_id = producerToProduct.producer_id,
                product_id = producerToProduct.product_id,
                producer_to_product_id = producerToProduct.producer_to_product_id

            };
            this.producerToProductRepository.Insert(producerToProductToAdd);
        }

        public void DeleteProducerToProduct(ProducerToProductDTO item)
        {
            //   var producerToProduct = this.producerToProductRepository.Get(x => x.producer_to_product_id == item.producer_to_product_id);
            var producersToProduct = this.producerToProductRepository.GetAll(x => x.producer_id == item.producer_id);
            foreach(ProducerToProduct ptp in producersToProduct.ToList())
            {
                this.producerToProductRepository.Delete(ptp);
            }
            //if (item == null)
            //{
            //    throw new ArgumentException("Cannot find producer with id: " + item.producer_to_product_id);
            //}

            //this.producerToProductRepository.Delete(producerToProduct);
        }

        public ProducerToProductDTO GetById(int id)
        {
            var producerToProduct = this.producerToProductRepository.Get(x => x.producer_to_product_id == id);
            return this.MapProducerToProduct(producerToProduct);
        }

       

        public void Update(ProducerToProductDTO producerToProduct)
        {
            // int producerToProductId = producerToProduct.product_id;
            //var producerToProductToUpdate = GetByProductId(producerToProduct.product_id);
            //  var producerToProductToUpdate = this.producerToProductRepository.Get(x=>x.producer_id==producerToProduct.producer_id);
            var producersToProductsToDelete = this.producerToProductRepository.GetAll(x => x.producer_id == producerToProduct.producer_id);
            foreach(ProducerToProduct ptp in producersToProductsToDelete.ToList())
            {
                this.producerToProductRepository.Delete(ptp);
            }
            //producerToProductToUpdate.product_id = producerToProduct.product_id;
           

           // AddNewProducerToProduct(producerToProduct);
//this.producerToProductRepository.Update(producerToProductToUpdate);

        }

        public ProducerToProductDTO GetByProductId(int id)
        {
            var producerToProduct = this.producerToProductRepository.Get(x => x.product_id== id);
            return this.MapProducerToProduct(producerToProduct);
            //return producerToProduct;
        }

       
           
    }
}