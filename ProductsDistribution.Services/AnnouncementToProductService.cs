using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.AnnouncementToProduct.Models;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;

namespace ProductsDistribution.Services
{
    public class AnnouncementToProductService : IAnnouncementToProductService
    {
        public readonly IRepository<AnnouncementToProduct> announcementToProductRepository;


        public AnnouncementToProductService(IRepository<AnnouncementToProduct> announcementToProductRepository)

        {
            this.announcementToProductRepository = announcementToProductRepository;


        }

        public AnnouncementToProductDTO MapAnnouncementToProduct(AnnouncementToProduct announcementToProduct)
        {
            return new AnnouncementToProductDTO()
            {
                announcement_to_product_id = announcementToProduct.announcement_to_product_id,
                announcement_id = announcementToProduct.announcement_id,
                max_quantity = announcementToProduct.max_quantity,
                product_id = announcementToProduct.product_id,
                price = announcementToProduct.price,
                arrive_date = announcementToProduct.arrive_date

            };
        }
        public void AddNewAnnouncementToProduct(AnnouncementToProductDTO announcementToProduct)
        {
            var announcementToProductToAdd = new AnnouncementToProduct
            {
              //  announcement_to_product_id = announcementToProduct.announcement_to_product_id,
                announcement_id = announcementToProduct.announcement_id,
                max_quantity = announcementToProduct.max_quantity,
                product_id = announcementToProduct.product_id,
                price = announcementToProduct.price,
                arrive_date = announcementToProduct.arrive_date
                
               
            };
            this.announcementToProductRepository.Insert(announcementToProductToAdd);
        }

        public void DeleteAnnouncementToProduct(AnnouncementToProductDTO item)
        {
            var announcementToProduct = this.announcementToProductRepository.Get(x => x.announcement_to_product_id == item.announcement_to_product_id);
            if (announcementToProduct == null)
            {

                throw new ArgumentException("Cannot find producer with id: " + item.announcement_to_product_id);

            }
            this.announcementToProductRepository.Delete(announcementToProduct);
        }

        public AnnouncementToProductDTO GetById(int id)
        {
            var announcementToProduct = this.announcementToProductRepository.Get(x => x.announcement_to_product_id == id);
            return this.MapAnnouncementToProduct(announcementToProduct);
        }

        public void Update(AnnouncementToProductDTO announcementToProduct)
        {
            var announcementToProductToUpdate = this.announcementToProductRepository.Get(x => x.announcement_to_product_id == announcementToProduct.announcement_to_product_id);
            announcementToProductToUpdate.announcement_id = announcementToProduct.announcement_id;
            announcementToProductToUpdate.max_quantity = announcementToProduct.max_quantity;
            announcementToProductToUpdate.product_id = announcementToProduct.product_id;
            announcementToProductToUpdate.price = announcementToProduct.price;
            announcementToProductToUpdate.arrive_date = announcementToProduct.arrive_date;
            this.announcementToProductRepository.Update(announcementToProductToUpdate);
        }
    }
}