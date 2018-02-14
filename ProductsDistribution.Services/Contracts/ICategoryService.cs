using ProductsDistribution.Core.Category.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface ICategoryService
    {
        CategoryDTO GetById(int id);

        int GetCategoryId(string categoryName);

        void AddNewCategory(CategoryDTO category);

        //CategoryDTO DeleteCategory(CategoryDTO item);
        void Update(CategoryDTO category);

        List<string> GetAllCategoryParentNames();

        List<string> GetAllCategoryNames();

        List<string> GetAllSubCategoriesByName(string categoryName);

        CategoryDTO GetCategoryByCategoryName(string categoryName);

        // CategoryDTO DeleteCategory(CategoryDTO item);
        void DeleteCategory(CategoryDTO item);

         List<Category> GetFullSubCategories(string categoryName);

        List<CategoryDTO> GetAllSubCategoriesById(int id);

        int CountSubCategories(int id);


    }
}