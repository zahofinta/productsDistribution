using ProductsDistribution.Core.Category.Models;
using ProductsDistribution.Models;
using ProductsDistribution.Models.InputModels;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        // GET: Category

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        private IEnumerable<CategoryViewModel> MapCategories(IEnumerable<CategoryDTO> categoriesDTO)
        {
            var categories = new List<CategoryViewModel>();

            foreach (var category in categoriesDTO)
            {
                categories.Add(new CategoryViewModel
                {
                    
                    category_name= category.category_name
                   
                });
            }

            return categories;
        }
        public ActionResult AddNewCategory()
        {
            CategoryInputModel inputModel = new CategoryInputModel
            {
                categories = GetCategories()
            };
            return View(inputModel);
            
          //  return View("AddNewCategory");
        }

      private IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.categoryService.GetAllCategoryNames();
           
            return new SelectList(categories);
        }

        [HttpPost]
        public ActionResult AddNewCategory(CategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                Response.StatusCode = 400; // Replace .AddHeader
                var error = new
                {
                    Message = "Request is not valid!"
                };
                return Json(error);
            }
            // var all_category_names = this.categoryService.GetAllCategoryNames();
            inputModel.categories = GetCategories();
            
            string selected_category = inputModel.selectedCategory;
            try
            {
                if (selected_category != null)
                {
                    int parent_id_selected = this.categoryService.GetCategoryId(selected_category);

                    this.categoryService.AddNewCategory(new CategoryDTO
                    {

                        category_name = inputModel.category_name,
                        category_description = inputModel.category_description,
                        CategoryDTO_parent_id = parent_id_selected

                    });
                }
                else
                {
                    this.categoryService.AddNewCategory(new CategoryDTO
                    {

                        category_name = inputModel.category_name,
                        category_description = inputModel.category_description,

                    });
                }

            }
            catch (DbUpdateException e)

            when (e.InnerException?.InnerException is SqlException sqlEx &&
            (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
             
                ModelState.AddModelError("category_name", "Категорията вече съществува");
                return View(inputModel);
            }
            
            //if (selected_category != null)
            //{
            //    int parent_id_selected = this.categoryService.GetCategoryId(selected_category);

            //    this.categoryService.AddNewCategory(new CategoryDTO
            //    {

            //        category_name = inputModel.category_name,
            //        category_description = inputModel.category_description,
            //        CategoryDTO_parent_id = parent_id_selected

            //    });
            //}
            //else
            //{
            //    this.categoryService.AddNewCategory(new CategoryDTO
            //    {

            //        category_name = inputModel.category_name,
            //        category_description = inputModel.category_description,

            //    });
            //}
            return View(inputModel);
        }
        /*public ActionResult DisplayCategories()
        {
           
            var categoriesDTO = this.categoryService.GetAllCategories();
            var categories = this.MapCategories(categoriesDTO);

            return this.PartialView("_DisplayCategories", categories);
        }*/
    }
}