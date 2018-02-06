﻿using ProductsDistribution.Core.Product.Models;
using ProductsDistribution.Models.InputModels
using ProductsDistribution.Models.ViewModels;
using ProductsDistribution.Services.Contracts;

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
            List<string> all_category_names = categoryService.GetAllCategoryNames();
            List<ProductViewModelShort> viewModel = new List<ProductViewModelShort>();
            foreach (string categoryName in all_category_names.ToList())
            {

                ProductViewModelShort element = new ProductViewModelShort();
              /*  element.product_name= this.categoryService.GetCategoryId(categoryName);
                element.category_name = categoryName;
                element.sub_categories = categoryService.GetAllSubCategoriesByName(categoryName);
                */
                viewModel.Add(element);

            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNewProduct(ProductInputModel inputModel)
        {
            inputModel.parent_categories = GetParentCategories();
            if (!this.ModelState.IsValid)
            {

                return View(inputModel);
            }
            string selected_parent_category = inputModel.selected_ParentCategory;
            inputModel.child_categories = GetChildCategories(selected_parent_category);
            string selected_child_category = inputModel.selected_ChildCategory;
            int selected_child_category_id = categoryService.GetCategoryId(selected_child_category);
       
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
                        categoryId = selected_child_category_id
                        

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