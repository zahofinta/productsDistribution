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


        ProductViewModelShort MapProductBaseDTOToProductViewModelShort(ProductBaseDTO element)
        {
            return new ProductViewModelShort
            {
                product_id = element.product_id,
                durability = element.durability,
                price = element.price,
                product_name = element.product_name,
                volume = element.volume,
                weight = element.weight,
                rating = element.rating,
                category = this.categoryService.GetById(element.categoryId).category_name

            };
        }

        public ActionResult DisplayProducts()
        {

            List<ProductViewModelShort> viewModel = new List<ProductViewModelShort>();
            string current_user = this.User.Identity.GetUserId();
            var all_products_by_user = this.productService.GetAllProductsByUser(current_user);
            foreach (ProductBaseDTO product_short in all_products_by_user)
            {

               // ProductViewModelShort element = new ProductViewModelShort();

               // element.product_id = product_short.product_id;
                //element.price = product_short.price;
                //element.rating = product_short.rating;
                //element.product_name = product_short.product_name;
                //element.volume = product_short.volume;
                //element.weight = product_short.weight;
                //element.durability = product_short.durability;
                //element.category = this.categoryService.GetById(product_short.categoryId).category_name;
                //element.userId = current_user;
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
                parent_categories = GetParentCategories()


            };

            return View(inputModel);


        }





        [HttpPost]
        public ActionResult AddNewProduct(ProductInputModel inputModel)
        {

            inputModel.parent_categories = GetParentCategories();
            string selected_parent_category = inputModel.selected_ParentCategory;
            inputModel.child_categories = GetChildCategories(selected_parent_category);
            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }


            string selected = inputModel.selected_ChildCategory;
            int selected_child_category_id = categoryService.GetCategoryId(selected);

            try
            {

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


        ProductInputEditModel MapProductBaseDTOToProductInputEditModel(ProductBaseDTO product)
        {
            return new ProductInputEditModel()
            {
                product_id = product.product_id,
                product_name = product.product_name,
                price = product.price,
                product_description = product.product_description,
                cut = product.cut,
                volume = product.volume,
                other = product.other,
                durability = product.durability,
                weight = product.weight,
                parent_categories = GetParentCategories(),
                userId = product.userId
            };

        }


        [HttpGet]
        public ActionResult EditProduct(int id,string userId)
        {
            userId = this.User.Identity.GetUserId();

            var product = this.productService.GetProductByIdAndUserId(id, userId);
           // var prod = this.productService.GetById(id);
            ProductInputEditModel model = MapProductBaseDTOToProductInputEditModel(product);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditProduct(int id,ProductInputEditModel inputEditModel)
        {
            inputEditModel.parent_categories = GetParentCategories();
            string selected_parent_category = inputEditModel.selected_ParentCategory;
            inputEditModel.child_categories = GetChildCategories(selected_parent_category);
            if (!this.ModelState.IsValid)
            {

                return View(inputEditModel);
            }


            string selected = inputEditModel.selected_ChildCategory;
            int selected_child_category_id = categoryService.GetCategoryId(selected);


            try
            {

                this.productService.Update(new ProductBaseDTO
                {
                    product_id = id,
                    product_name = inputEditModel.product_name,
                    product_description = inputEditModel.product_description,
                    price = inputEditModel.price,
                    cut = inputEditModel.cut,
                    durability = inputEditModel.durability,
                    other = inputEditModel.other,
                    volume = inputEditModel.volume,
                    weight = inputEditModel.weight,
                    categoryId = selected_child_category_id,

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
    }
}