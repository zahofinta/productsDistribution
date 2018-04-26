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
using ProductsDistribution.Core.ProducerToProduct.Models;

namespace ProductsDistribution.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;
        private readonly IProductService productService;
        private readonly IProducerToProductService producerToProductService;
        public ProducerController(IProducerService producerService, IProductService productService, IProducerToProductService producerToProductService)
        {
            this.producerService = producerService;
            this.productService = productService;
            this.producerToProductService = producerToProductService;
        }
           
        // GET: Producer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCurrentUserProducts()

            {
                var products_by_current_user = this.productService.GetAllProductsByUser(this.User.Identity.GetUserId());

                return Json(products_by_current_user, JsonRequestBehavior.AllowGet);
            }
            ProducerViewModelShort MapProducerDTOToProducerViewModelShort(ProducerDTO producer)
        {
            return new ProducerViewModelShort
            {
                producer_id= producer.producer_id,
                producer_email = producer.producer_email,
                producer_name = producer.producer_name,
                rating = producer.rating,
                producer_products = this.productService.GetAllSelectedProductNamesByUserId(this.User.Identity.GetUserId(),producer.producer_id),
                userId = producer.userId
             
            };
        }

        ProducerViewModelFullDetails MapProducerDTOToProducerViewModelFullDetails(ProducerDTO producer)
        {

            return new ProducerViewModelFullDetails()
            {
                producer_id = producer.producer_id,
                producer_name = producer.producer_name,
                producer_address = producer.producer_address,
                producer_email = producer.producer_email,
                rating = producer.rating,
                telephone_number = producer.telephone_number,
                userId = producer.userId,
                producer_products = this.productService.GetAllSelectedProductNamesByUserId(this.User.Identity.GetUserId(),producer.producer_id)
               
            };
        }
        ProducerInputEditModel MapProducerDTOToProducerInputEditModel(ProducerDTO producer)
        {
            return new ProducerInputEditModel()
            {
                producer_id = producer.producer_id,
                producer_name = producer.producer_name,
                producer_address = producer.producer_address,
                producer_email = producer.producer_email,
                telephone_number = producer.telephone_number,
                //products = GetCurrentUserProducts(),
                userId = producer.userId,
               
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
               // products = GetCurrentUserProducts()
            };
            return View(producerInputModel);
        }

        [HttpPost]
        public ActionResult AddNewProducer(ProducerInputModel inputModel)
        {
           // inputModel.products = GetCurrentUserProducts();
            //var test = this.producerService.GetProductNamesByProducerNameAndUserId("dada", this.User.Identity.GetUserId());

            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }
            
            try
            {
                ProducerDTO producerToInsert = new ProducerDTO();
                producerToInsert.producer_name = inputModel.producer_name;
                producerToInsert.producer_email = inputModel.producer_email;
                producerToInsert.producer_address = inputModel.producer_address;
                producerToInsert.telephone_number = inputModel.telephone_number;
                producerToInsert.userId = this.User.Identity.GetUserId();

                int addedProducerId = this.producerService.AddNewProducer(producerToInsert);

                List<string> selected_products = inputModel.selected_products;

                if (selected_products != null)
                {
                    if (selected_products.Count() > 0)
                    {
                        foreach (string selected_product in selected_products)
                        {
                            
                                this.producerToProductService.AddNewProducerToProduct(new ProducerToProductDTO()
                                {

                                    producer_id = addedProducerId,
                                    product_id = this.productService.GetProductIdByName(selected_product, this.User.Identity.GetUserId())

                                });
                            
                        }

                    }

                }
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

        [HttpGet]
        public ActionResult EditProducer(int id, string userId)
        {
            userId = this.User.Identity.GetUserId();
            var producer = this.producerService.GetProducerByIdAndUserId(id, userId);

            if (producer == null)
            {
                return HttpNotFound();

            }

            ProducerInputEditModel producerInputEditModel = MapProducerDTOToProducerInputEditModel(producer);

            return View(producerInputEditModel);

        }
        [HttpPost]
        public ActionResult EditProducer(int id,ProducerInputEditModel inputEditModel)
        {
           // inputEditModel.products = GetCurrentUserProducts();
            if (!this.ModelState.IsValid)
            {

                return View(inputEditModel);
            }

            try
            {
                //var producerToEdit = this.producerService.GetById(id);


                this.producerService.Update(new ProducerDTO
                {
                    producer_id = id,
                    producer_name = inputEditModel.producer_name,
                    producer_address = inputEditModel.producer_address,
                    producer_email = inputEditModel.producer_email,
                    telephone_number = inputEditModel.telephone_number
                });
                
                List<string> selected_products = inputEditModel.selected_products;

                if(selected_products!=null)
                {
                    if (selected_products.Count() > 0)
                    {

                        this.producerToProductService.Update(new ProducerToProductDTO()
                        {

                            producer_id = id

                        });


                        foreach (string selected_product in selected_products)
                        {
                            //this.producerToProductService.Update(new ProducerToProductDTO()
                            //{

                            //    producer_id = id,
                            //    product_id = this.productService.GetProductIdByName(selected_product, this.User.Identity.GetUserId())

                            //});
                        
                            
                                this.producerToProductService.AddNewProducerToProduct(new ProducerToProductDTO()
                                {

                                    producer_id = id,
                                    product_id = this.productService.GetProductIdByName(selected_product, this.User.Identity.GetUserId())

                                });
                            

                        }
                    }
                }

            }
            catch (DbUpdateException e)

             when (e.InnerException?.InnerException is SqlException sqlEx &&
             (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {

                ModelState.AddModelError("producer_name", "Производителят вече съществува");
                return View(inputEditModel);
            }

            return RedirectToAction("DisplayProducers");

        }
        public ActionResult Delete(int id, string userId)
        {
            userId = this.User.Identity.GetUserId();
            var producer = this.producerService.GetProducerByIdAndUserId(id,userId);


            if (producer== null)
            {
                return HttpNotFound();
            }
            this.producerToProductService.DeleteProducerToProduct(new ProducerToProductDTO()
            {

                producer_id = id
            });
            this.producerService.DeleteProducer(producer);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var producer = this.producerService.GetById(id);

            ProducerViewModelFullDetails model = MapProducerDTOToProducerViewModelFullDetails(producer);

            if (producer == null)
            {
                return HttpNotFound();
            }
            // return View(model);
            return View(model);
        }
    }
}