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
namespace ProductsDistribution.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }
        // GET: Producer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddNewProducer()
        {
            ProducerInputModel producerInputModel = new ProducerInputModel();
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