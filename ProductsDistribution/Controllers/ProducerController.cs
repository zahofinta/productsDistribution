using ProductsDistribution.Core.Producer.Models;
using ProductsDistribution.Models.InputModels;
using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProductsDistribution.Models.ViewModels;

namespace ProductsDistribution.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;
        private readonly IProductService productService;
        public ProducerController(IProducerService producerService, IProductService productService)
        {
            this.producerService = producerService;
            this.productService = productService;
        }
        // GET: Producer
        public ActionResult Index()
        {
            return View();
        }
        ProducerViewModelShort MapProducerDTOToProducerViewModelShort(ProducerDTO producer)
        {
            return new ProducerViewModelShort
            {
                producer_id= producer.producer_id,
                producer_email = producer.producer_email,
                producer_name = producer.producer_name,
                rating = producer.rating
             

            };
        }
        public ActionResult DisplayProducers()
        {
            List<ProducerViewModelShort> viewModel = new List<ProducerViewModelShort>();
            string current_user = this.User.Identity.GetUserId();
            var all_products_by_user = this.producerService.GetAllProducersByUserShort(current_user);
            foreach(ProducerDTO producer in all_products_by_user)
            {
                viewModel.Add(MapProducerDTOToProducerViewModelShort(producer));
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddNewProducer()
        {
            ProducerInputModel producerInputModel = new ProducerInputModel()
            {
                selected_products = this.productService.GetListOfProductNamesByUserId(this.User.Identity.GetUserId())
            };
            return View(producerInputModel);
        }

        [HttpPost]
        public ActionResult AddNewProducer(ProducerInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }
            try
            {
                this.producerService.AddNewProducer(new ProducerDTO

                {
                    producer_name = inputModel.producer_name,
                    producer_email = inputModel.producer_email,
                    producer_address = inputModel.producer_address,
                    telephone_number = inputModel.telephone_number,
                    userId = this.User.Identity.GetUserId(),

                });

                    
            }
            catch (DbUpdateException e)

             when (e.InnerException?.InnerException is SqlException sqlEx &&
             (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {

                ModelState.AddModelError("producer_name", "Производителят вече съществува");
                return View(inputModel);
            }
            return RedirectToAction("DisplayProducers");
        }
    }
}