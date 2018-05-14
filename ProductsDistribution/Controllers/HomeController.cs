using ProductsDistribution.Core.Announcement.Models;
using ProductsDistribution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProductsDistribution.Models.ViewModels;

namespace ProductsDistribution.Controllers
{
    public class HomeController : Controller
    {



        private readonly SearchService searchService;

        // GET: Category

        public HomeController(SearchService searchService)
        {
            this.searchService = searchService;

        }

        public JsonResult GetAllAnnouncements()
        {
            var DbResult = this.searchService.SearchRepository.GetAllAnnouncements();
            
            return Json(DbResult, JsonRequestBehavior.AllowGet);
        }
        // GET: Search
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
        public ActionResult GetSearchRecord(string searchString)
        {
            //  int pageSize = 10;


            //var announcements=null;
            var searchResult = searchService.SearchRepository.GetAllAnnouncements();
            List<AnnouncementViewModel> announcements = new List<AnnouncementViewModel>();
            if (!String.IsNullOrEmpty(searchString))
            {
                 searchResult = searchResult.Where(x=>x.title.Contains(searchString));
                foreach (var element in searchResult.ToList())
                {
                    announcements.Add(MapAnnouncementDTOToAnnouncementViewModel(element));
                }

            }
            //  switch (sortOption)
            // {
            //case "title_acs":
            //    announcements = announcements.OrderBy(x => x.title);
            //    break;
            //case "title_desc":
            //    searchResult = searchResult.OrderByDescending(x=>x.title);
            //    break;
            //case "price_acs":
            //    products = products.OrderBy(p => p.Price);
            //    break;
            //case "price_desc":
            //    products = products.OrderByDescending(p => p.Price);
            //    break;

            //case "qty_acs":
            //    products = products.OrderBy(p => p.Qty);
            //    break;
            //case "qty_desc":
            //    products = products.OrderByDescending(p => p.Qty);
            //    break;
            //default:
            //    products = products.OrderBy(p => p.Id);
            //    break;

            //}
           // ViewBag.AnnouncementList = announcements;
           // return PartialView("SearchPartial",announcements);

            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("SearchPartial", announcements)
                : View(announcements);
                
        }

        public ActionResult Index()
        {
            var searchResult = searchService.SearchRepository.GetAllAnnouncements();
            List<AnnouncementViewModel> announcements = new List<AnnouncementViewModel>();
            foreach(var element in searchResult.ToList())
            {
                announcements.Add(MapAnnouncementDTOToAnnouncementViewModel(element));
            }
            ViewBag.AnnouncementList = announcements;
            return View();
        }
        public PartialViewResult AjaxSearchView(string name)
        {
            var producersAndProducts = searchService.GetProducersAndProductsNames(name).Take(10);
            return this.PartialView(producersAndProducts);
        }
        
    }
}