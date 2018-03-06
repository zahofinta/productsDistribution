using Microsoft.AspNet.Identity;
using ProductsDistribution.Core.Announcement.Models;
using ProductsDistribution.Core.AnnouncementToProduct.Models;
using ProductsDistribution.Models.InputModels;
using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IProducerService producerService;
        private readonly IProductService productService;
        private readonly IAnnouncementToProductService AnnouncementToProductService;
        private readonly IAnnouncementService announcementService;
        public AnnouncementController(IProducerService producerService, IProductService productService, IAnnouncementToProductService AnnouncementToProductService, IAnnouncementService announcementService)
        {
            this.producerService = producerService;
            this.productService = productService;
            this.AnnouncementToProductService = AnnouncementToProductService;
            this.announcementService = announcementService;
        }
        // GET: Announcement
        public ActionResult Index()
        {
            return View();



        }
        public ActionResult LoadBlankFormView(int id)
        {
            return PartialView("_ProductAnnouncementInputModel",id);
        }

        private IEnumerable<SelectListItem> GetProducerNamesByUserId()
        {
            var producers = this.producerService.GetProducerNamesByUserId(this.User.Identity.GetUserId());

            return new SelectList(producers);
        }

        private IEnumerable<SelectListItem> GetProductNamesByProducerNameAndUserId(string producerName)
        {
            var producers = this.producerService.GetProductNamesByProducerNameAndUserId(producerName,this.User.Identity.GetUserId());

            return new SelectList(producers);
        }

        public virtual JsonResult LoadProducerNamesByUserId()
        {
            var producers = this.producerService.GetProducerNamesByUserId(this.User.Identity.GetUserId());

            return Json(producers, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddNewAnnouncement()
        {
            AnnouncementInputModel announcement = new AnnouncementInputModel()
            {

                //    producerNames = GetProducerNamesByUserId()
                announcementInfo = new List<AnnouncementInfo>()

                //};
            };
            return View(announcement);
        }
        [HttpPost]

        public ActionResult AddNewAnnouncement(AnnouncementInputModel inputModel)
        {
            //inputModel.producerNames = GetProducerNamesByUserId();
          //  string selected_producerName = inputModel.selected_producerName;
          //  ProductAnnouncementInputModel p = new ProductAnnouncementInputModel();
          //  p.productNames = GetProductNamesByProducerNameAndUserId(selected_producerName);
            // po dadeno ime na proizvoditel i id na potrebitel da se izkarat vsichkite imena na  produkti
            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }

           /* this.announcementService.AddNewAnnouncement(new AnnouncementDTO
            {
                arrive_date = inputModel.arrive_date,
                status = 0,
                userId = this.User.Identity.GetUserId(), 

            });
            */
           /*  this.AnnouncementToProductService.AddNewAnnouncementToProduct(new AnnouncementToProductDTO
            {
                

            });
            */

            return View(inputModel);
        }
    }
}