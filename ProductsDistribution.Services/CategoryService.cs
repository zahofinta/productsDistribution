﻿using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Category.Models;
using System.Data.Entity;
using ProductsDistribution.Data;
using ProductsDistribution.Data.Repositories;

namespace ProductsDistribution.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly IRepository<Category> categoryRepository;
        public readonly CategoryRepository CategoryRepository;
        

        public CategoryService(IRepository<Category> categoryRepository,CategoryRepository CategoryRepository)
                             
        {
            this.categoryRepository = categoryRepository;
            this.CategoryRepository = CategoryRepository;
            
        }

        public void AddNewCategory(CategoryDTO category)
        {
            var categoryToAdd = new Category
            {
                category_id = category.category_id,
                category_name = category.category_name,
                category_description = category.category_description,
                Category_parent_id = category.CategoryDTO_parent_id
            };
            this.categoryRepository.Insert(categoryToAdd);
        }

       /* public CategoryDTO DeleteCategory(CategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            throw new NotImplementedException();
        }*/

          

        public CategoryDTO GetById(int id)
        {
            var category = this.categoryRepository.Get(x => x.category_id == id);
            return this.MapCategory(category);
        }

        public void Update(CategoryDTO category)
        {
            var categoryToUpdate = this.categoryRepository.Get(x => x.category_id == category.category_id);
            categoryToUpdate.category_name = category.category_name;
            categoryToUpdate.category_description = category.category_description;
            categoryToUpdate.Category_parent_id = category.CategoryDTO_parent_id;

            this.categoryRepository.Update(categoryToUpdate);
        }

        public CategoryDTO MapCategory(Category category)
        {
            return new CategoryDTO()
            {
                category_id = category.category_id,
                category_name = category.category_name,
                category_description = category.category_description,
                CategoryDTO_parent_id = category.Category_parent_id,
                
            };
        }

        public IEnumerable<CategoryDTO> GetAllCategoryNamesAndIds()
        {
            var all_category_names_and_ids = categoryRepository.GetAll().Select(x => new CategoryDTO { category_id = x.category_id,category_name = x.category_name });
           
            return all_category_names_and_ids;
        }

        public int GetCategoryId(string categoryName)
        {
           return  CategoryRepository.GetCategoryId(categoryName);
        }
       public List<string> GetAllCategoryNames()
        {
            return CategoryRepository.GetAllCategoryNames();
        }

        public List<string> GetAllSubCategoriesByName(string categoryName)
        {
            return CategoryRepository.GetAllSubCategories(categoryName);
        }
    }
    
}