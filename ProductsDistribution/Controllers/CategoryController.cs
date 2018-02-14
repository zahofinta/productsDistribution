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
        private readonly IProductService productService;

        // GET: Category

        public CategoryController(ICategoryService categoryService,IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult AddNewCategory()
        {
            CategoryInputModel inputModel = new CategoryInputModel
            {
                categories = GetCategories()
            };
            return View(inputModel);

         
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            var categories = this.categoryService.GetAllCategoryParentNames();

            return new SelectList(categories);
        }

        public Category MapCategory(CategoryDTO category)
        {
            return new Category()
            {
                category_id = category.category_id,
                category_name = category.category_name,
                category_description = category.category_description,
                Category_parent_id = category.CategoryDTO_parent_id,
                children = this.categoryService.GetFullSubCategories(category.category_name)


            };
        }

        [HttpPost]
        public ActionResult AddNewCategory(CategoryInputModel inputModel)
        {
            inputModel.categories = GetCategories();
            if (!this.ModelState.IsValid)
            {
               
                return View(inputModel);
            }
  
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


             return RedirectToAction("DisplayCategories"); 
            
        }
        public ActionResult DisplayCategories()
        {
            List<string> all_category_names = categoryService.GetAllCategoryNames();
            List<CategoryViewModel> viewModel = new List<CategoryViewModel>();
            foreach (string categoryName in all_category_names.ToList())
            {

                CategoryViewModel element = new CategoryViewModel();
                element.category_id = this.categoryService.GetCategoryId(categoryName);
                element.category_name = categoryName;
                element.sub_categories = categoryService.GetAllSubCategoriesByName(categoryName);
                viewModel.Add(element);

            }

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
         
            CategoryDTO category = this.categoryService.GetById(id);
            List<CategoryDTO> all_children_for_category = this.categoryService.GetAllSubCategoriesById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

           bool isInProducts = this.productService.isInProducts(id);

           int count_sub_categories = this.categoryService.CountSubCategories(id);

           

            //your deletetion code
            if (!isInProducts && count_sub_categories==0)
            {
                foreach (CategoryDTO cat in all_children_for_category)
                {
                    cat.CategoryDTO_parent_id = null;
                    this.categoryService.DeleteCategory(cat);
                }

                this.categoryService.DeleteCategory(category);
            }
            else
            {

               TempData["Error"]= "Категорията има прикрепени продукти към нея или категорията е главна.За да изтриете категорията не трябва да има прикрепени продукти към нея и трябва да е подкатегория на друга категория.";
                //return Redirect(Request.UrlReferrer.ToString());
              //  return RedirectToAction("DisplayCategories");


            }
           
            // bool isInProducts = this.productService.isInProducts(category.category_id);

            //vsichki kategorii koito sa deca na category
        
             return RedirectToAction("DisplayCategories");
  
        }
        CategoryInputEditModel MapCategoryDTOToCategoryInputEditModel(CategoryDTO category)
        {
            return new CategoryInputEditModel()
            {
                category_id = category.category_id,
                category_name = category.category_name,
                category_description = category.category_description,
                categories = GetCategories(),
                
            };

        }
        [HttpGet]
        public ActionResult EditView(int id)
        {
            var category = this.categoryService.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryInputEditModel model = MapCategoryDTOToCategoryInputEditModel(category);
          
            return View(model);
           
        }
        [HttpPost]
        public ActionResult EditView(int id,CategoryInputEditModel inputEditModel)
        {
            inputEditModel.categories = GetCategories();
            if (!this.ModelState.IsValid)
            {
                //Response.StatusCode = 400; // Replace .AddHeader
                //var error = new
                //{
                //    Message = "Request is not valid!"
                //};
                //return Json(error);
                return View(inputEditModel);
            }
            // var all_category_names = this.categoryService.GetAllCategoryNames();
           // inputEditModel.categories = GetCategories();

            string selected_category = inputEditModel.selectedCategory;
            try
            {
                if (selected_category != null)
                {
                    int parent_id_selected = this.categoryService.GetCategoryId(selected_category);

                    this.categoryService.Update(new CategoryDTO
                    {
                        category_id = id,
                        category_name = inputEditModel.category_name,
                        category_description = inputEditModel.category_description,
                        CategoryDTO_parent_id = parent_id_selected

                    });
                }
                else
                {
                    this.categoryService.Update(new CategoryDTO
                    {
                        category_id = id,
                        category_name = inputEditModel.category_name,
                        category_description = inputEditModel.category_description,

                    });
                }

            }
            catch (DbUpdateException e)

            when (e.InnerException?.InnerException is SqlException sqlEx &&
            (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {

                ModelState.AddModelError("category_name", "Категорията вече съществува");
                return View(inputEditModel);
            }
            /*  this.categoryService.Update(new CategoryDTO()
              {
                  category_id = id,
                  category_name = inputEditModel.category_name,
                  category_description = inputEditModel.category_description

              });*/

            //  return View(inputEditModel);
            return RedirectToAction("DisplayCategories");
        }
    }
}