using Microsoft.AspNet.Identity;
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
        public AnnouncementController(IProducerService producerService, IProductService productService, IAnnouncementToProductService AnnouncementToProductService)
        {
            this.producerService = producerService;
            this.productService = productService;
            this.AnnouncementToProductService = AnnouncementToProductService;
        }
        // GET: Announcement
        public ActionResult Index()
        {
            return View();


        }

        private IEnumerable<SelectListItem> GetProducerNamesByUserId()
        {
            var producers = this.producerService.GetProducerNamesByUserId(this.User.Identity.GetUserId());

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
            AnnouncementInputModel announcement = new AnnouncementInputModel() {

                producerNames = GetProducerNamesByUserId()

            };

            return View(announcement);
        }
        [HttpPost]

        public ActionResult AddNewAnnouncement(AnnouncementInputModel inputModel)
        {
            inputModel.producerNames = GetProducerNamesByUserId();
            string selected_producerName = inputModel.selected_producerName;
            
            // po dadeno ime na proizvoditel i id na potrebitel da se izkarat vsichkite imena na  produkti
            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }

            return View(inputModel);
        }
    }
}