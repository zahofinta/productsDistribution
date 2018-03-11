using ProductsDistribution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AjaxSearchView(string name)
        {
            var producersAndProducts = searchService.GetProducersAndProductsNames(name).Take(10);
            return this.PartialView(producersAndProducts);
        }
        
    }
}