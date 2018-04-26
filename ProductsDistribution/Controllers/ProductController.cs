using ProductsDistribution.Core.Product.Models;
using ProductsDistribution.Models.InputModels;
using ProductsDistribution.Models.ViewModels;
using ProductsDistribution.Services.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProductsDistribution.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetCategoriesTreeView()
        {
            var DbResult = this.categoryService.GetAllCategories();
            return Json(DbResult, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> GetParentCategories()
        {
            var categories = this.categoryService.GetAllCategoryParentNames();

            return new SelectList(categories);
        }

        private IEnumerable<SelectListItem> GetChildCategories(string parent_category)
        {
            var sub_categories = this.categoryService.GetAllSubCategoriesByName(parent_category);

            return new SelectList(sub_categories);
        }

        private IEnumerable<SelectListItem> GetUnits()
        {

            var units = new List<String>()
            {
                "кг.","бр.","литър/литри","мл.","гр."
            };

            return new SelectList(units);
        }

        private IEnumerable<SelectListItem> GetCuts()
        {

            var cuts = new List<String>()
            {
                "пакет","кутия","буркан","бутилка","връзка","друго"
            };

            return new SelectList(cuts);
        }


        ProductViewModelShort MapProductBaseDTOToProductViewModelShort(ProductBaseDTO product)
        {
            return new ProductViewModelShort
            {
                product_id = product.product_id,
                durability = product.durability,
                product_name = product.product_name,
                category = this.categoryService.GetById(product.categoryId).category_name
                
            };
        }


        ProductInputEditModel MapProductBaseDTOToProductInputEditModel(ProductBaseDTO product)
        {
            return new ProductInputEditModel()
            {
                product_id = product.product_id,
                product_name = product.product_name,
               
                product_description = product.product_description,
                selected_cut = product.cut,
                volume = product.volume,
                other = product.other,
                selected_unit = product.unit,
                durability = product.durability,
                weight = product.weight,
                userId = product.userId,
                units = GetUnits(),
                cuts = GetCuts()
            };

        }

        ProductViewModelFullDetails MapProductBaseDTOToProductViewModelFullDetails(ProductBaseDTO product)
        {

            return new ProductViewModelFullDetails()
            {
                product_id = product.product_id,
                product_name = product.product_name,
              
                product_description = product.product_description,
                cut = product.cut,
                volume = product.volume,
                other = product.other,
                durability = product.durability,
                weight = product.weight,
                userId = product.userId,
                rating = product.rating,
                category = this.categoryService.GetById(product.categoryId).category_name,
                unit = product.unit
            };
        }

        public ActionResult DisplayProducts()
        {

            List<ProductViewModelShort> viewModel = new List<ProductViewModelShort>();
            string current_user = this.User.Identity.GetUserId();
            var all_products_by_user = this.productService.GetAllProductsByUser(current_user);
            foreach (ProductBaseDTO product_short in all_products_by_user)
            {
                viewModel.Add(MapProductBaseDTOToProductViewModelShort(product_short));
            }

            return View(viewModel);
        }

        public ActionResult GetAllChildCategories(string categoryName)
        {
            var child_categories = this.categoryService.GetAllSubCategoriesByName(categoryName);
            return Json(child_categories, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddNewProduct()
        {

            ProductInputModel inputModel = new ProductInputModel
            {
                //parent_categories = GetParentCategories(),
                units = GetUnits(),
                cuts = GetCuts()

            };

            return View(inputModel);


        }

       


        [HttpPost]
   
        public ActionResult AddNewProduct(ProductInputModel inputModel)
        {
            inputModel.units = GetUnits();
            inputModel.cuts = GetCuts();
          
            if (!this.ModelState.IsValid)
            {
                
                return View(inputModel);
            }

           
                try
                {

                    this.productService.AddNewProduct(new ProductBaseDTO
                    {

                        product_name = inputModel.product_name,
                        product_description = inputModel.product_description,

                        cut = inputModel.selected_cut,
                        durability = inputModel.durability,
                        other = inputModel.other,
                        volume = inputModel.volume,
                        weight = inputModel.weight,
                        rating = 0.0,
                        categoryId = this.categoryService.GetCategoryId(inputModel.selected_category),
                        userId = this.User.Identity.GetUserId(),
                        unit = inputModel.selected_unit


                    });

                }
                catch (DbUpdateException e)

                when (e.InnerException?.InnerException is SqlException sqlEx &&
                (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {

                    ModelState.AddModelError("product_name", "Продуктът вече съществува");
                    return View(inputModel);
                }
            


            return RedirectToAction("DisplayProducts");

        }

        [HttpGet]
        public ActionResult EditProduct(int id,string userId)
        {
            userId = this.User.Identity.GetUserId();

            var product = this.productService.GetProductByIdAndUserId(id, userId);
            // var prod = this.productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductInputEditModel model = MapProductBaseDTOToProductInputEditModel(product);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditProduct(int id,ProductInputEditModel inputEditModel)
        {
           
            inputEditModel.units = GetUnits();
            inputEditModel.cuts = GetCuts();

          
            if (!this.ModelState.IsValid)
            {

                return View(inputEditModel);
            }
           

                try
                {

                    this.productService.Update(new ProductBaseDTO
                    {
                        product_id = id,
                        product_name = inputEditModel.product_name,
                        product_description = inputEditModel.product_description,

                        cut = inputEditModel.selected_cut,
                        durability = inputEditModel.durability,
                        other = inputEditModel.other,
                        volume = inputEditModel.volume,
                        weight = inputEditModel.weight,
                        categoryId = this.categoryService.GetCategoryId(inputEditModel.selected_category),
                        unit = inputEditModel.selected_unit

                    });

                }
                catch (DbUpdateException e)

                when (e.InnerException?.InnerException is SqlException sqlEx &&
                (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {

                    ModelState.AddModelError("product_name", "Продуктът вече съществува");
                    return View(inputEditModel);
                }

            
            return RedirectToAction("DisplayProducts");


        
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var product = this.productService.GetById(id);

            ProductViewModelFullDetails model = MapProductBaseDTOToProductViewModelFullDetails(product);
           
            if(product==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id, string userId)
        {
            userId = this.User.Identity.GetUserId();
            var product = this.productService.GetProductByIdAndUserId(id, userId);


            if (product == null)
            {
                return HttpNotFound();
            }
            this.productService.DeleteProduct(product);
            return Redirect(Request.UrlReferrer.ToString());
        }


    }
}