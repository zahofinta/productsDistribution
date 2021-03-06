﻿using Microsoft.AspNet.Identity;
using ProductsDistribution.Core.Announcement.Models;
using ProductsDistribution.Core.AnnouncementToProduct.Models;
using ProductsDistribution.Models.InputModels;
using ProductsDistribution.Models.ViewModels;
using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
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
        public virtual JsonResult LoadProductNamesByProducerNameAndUserId(string producerName)
        {
            var producers = this.producerService.GetProductNamesByProducerNameAndUserId(producerName, this.User.Identity.GetUserId());
            return Json(producers, JsonRequestBehavior.AllowGet);
        }
      

        AnnouncementViewModel MapAnnouncementDTOToAnnouncementViewModel(AnnouncementDTO announcement)
        {
            return new AnnouncementViewModel
            {
                announcement_id = announcement.announcement_id,
                arrive_date = announcement.arrive_date,
                publish_date = announcement.publish_date,
                title = announcement.title

            };
        }

       // [ChildActionOnly]
        public ActionResult DisplayAllAnnouncements()
        {

            List<AnnouncementViewModel> viewModel = new List<AnnouncementViewModel>();
           // string current_user = this.User.Identity.GetUserId();
            var all_announcements = this.announcementService.GetAllAnnouncements();
            foreach (AnnouncementDTO announcement in all_announcements)
            {
                
                viewModel.Add(MapAnnouncementDTOToAnnouncementViewModel(announcement));
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddNewAnnouncement()
        {
            // AnnouncementInfoInputModel ai = new AnnouncementInfoInputModel();

          //   ai.announcement.producerNames = GetProducerNamesByUserId();
           // List<AnnouncementInfo> ai = new List<AnnouncementInfo>();
      
            AnnouncementInfo ai = new AnnouncementInfo();
            ai.firstProductInfo.producerNames= GetProducerNamesByUserId();
            return View(ai);
        }


        public JsonResult RedirectToHomePage()
        {
            return Json(new { redirect = "Home" }, JsonRequestBehavior.AllowGet);
        }
      
        [HttpPost]

        //tyka e problema !!!
        //mai trqbva kato input da e obekt ot AnnouncementInfo
        public ActionResult AddNewAnnouncement(AnnouncementInfo inputModel)

        {
            //AnnouncementInfo ai = new AnnouncementInfo();
         


            if (!this.ModelState.IsValid)
            {
                return View(inputModel);
            }
            


            AnnouncementInfo ai = inputModel;

          //  ai.remainingProducts = inputModel;


            AnnouncementDTO announcementToInsert = new AnnouncementDTO();
            announcementToInsert.title = inputModel.title;
            announcementToInsert.publish_date = DateTime.Now;
            announcementToInsert.arrive_date = inputModel.arrive_date;
            announcementToInsert.status = 0;
            announcementToInsert.userId = this.User.Identity.GetUserId();

            int addedAnnouncementID = this.announcementService.AddNewAnnouncement(announcementToInsert);

            foreach (var item in inputModel.remainingProducts)
            {
                this.AnnouncementToProductService.AddNewAnnouncementToProduct(new AnnouncementToProductDTO()
                {
                    announcement_id = addedAnnouncementID,
                   // arrive_date = item.arrive_date,
                    max_quantity = item.quantity,
                    price = item.price,
                    product_id = this.productService.GetProductIdByName(item.selected_productName,this.User.Identity.GetUserId())

                });
            }
             return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });

            //return JavaScript("window.location='/Index/Home'");
          //  return RedirectToAction("Index", "Home");
            // return View(inputModel);
              //return Json(Url.Action("Index", "Home"));

        }

       
    }
}