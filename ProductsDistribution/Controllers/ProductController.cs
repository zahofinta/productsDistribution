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

namespace ProductsDistribution.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index()
        {
            
            return View();
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

        public ActionResult DisplayProducts()
        {
           
            List<ProductViewModelShort> viewModel = new List<ProductViewModelShort>();
            string current_user = this.User.Identity.GetUserId();
            var all_products_by_user = this.productService.GetAllProductsByUser(current_user);
            foreach (var product_short in all_products_by_user.ToList())
            {
                
                ProductViewModelShort element = new ProductViewModelShort();
                element.product_name = product_short.product_name;
                element.price = product_short.price;
                element.durability = product_short.durability;
                element.rating = product_short.rating;
                element.volume = product_short.volume;
                element.weight = product_short.weight;
                element.category = this.categoryService.GetById(product_short.categoryId).category_name;

                viewModel.Add(element);

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
                parent_categories = GetParentCategories()
                
            };
           //string selected = inputModel.selected_ParentCategory;
           // inputModel.child_categories = GetChildCategories(selected);
           
            return View(inputModel);


        }

       /* [HttpPost]
        public ActionResult AddNewProduct(ProductInputModel inputModel)
        {
            inputModel.parent_categories = GetParentCategories();

            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }
            string selected_parent_category = inputModel.selected_ParentCategory;
            inputModel.child_categories = GetChildCategories(selected_parent_category);
            //  string selected_value = selected

            string selected = inputModel.selected_ChildCategory;
            int selected_child_category_id = categoryService.GetCategoryId(selected);

            try
            {

                //int parent_id_selected = this.productService.GetCategoryId(selected_category);

                this.productService.AddNewProduct(new ProductBaseDTO
                {
                    product_name = inputModel.product_name,
                    product_description = inputModel.product_description,
                    price = inputModel.price,
                    cut = inputModel.cut,
                    durability = inputModel.durability,
                    other = inputModel.other,
                    volume = inputModel.volume,
                    weight = inputModel.weight,
                    rating = 0.0,
                    categoryId = selected_child_category_id,
                    userId = this.User.Identity.GetUserId()


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

        } */



        [HttpPost]
        public  ActionResult AddNewProduct(ProductInputModel inputModel)
        {
            
            inputModel.parent_categories = GetParentCategories();
           
            if (!this.ModelState.IsValid)
            {
                
                return View(inputModel);
            }
            string selected_parent_category = inputModel.selected_ParentCategory;
            inputModel.child_categories = GetChildCategories(selected_parent_category);
            
            string selected = inputModel.selected_ChildCategory;  
            int selected_child_category_id = categoryService.GetCategoryId(selected);
       
            try
            {
              
                    //int parent_id_selected = this.productService.GetCategoryId(selected_category);

                    this.productService.AddNewProduct(new ProductBaseDTO
                    {
                        product_name = inputModel.product_name,
                        product_description = inputModel.product_description,
                        price = inputModel.price,
                        cut = inputModel.cut,
                        durability = inputModel.durability,
                        other = inputModel.other,
                        volume = inputModel.volume,
                        weight = inputModel.weight,
                        rating = 0.0,
                        categoryId = selected_child_category_id,
                        userId = this.User.Identity.GetUserId()
                        

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
    }
}