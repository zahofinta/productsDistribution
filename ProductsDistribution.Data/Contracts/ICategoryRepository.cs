using ProductsDistribution.Core.Category.Models;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        int GetCategoryId(string categoryName);
        List<string> GetAllCategoryParentNames();

        List<string> GetAllSubCategories(string categoryName);

        CategoryDTO GetCategoryByName(string categoryName);

        List<CategoryDTO> GetAllSubCategoriesById(int id);

        List<string> GetAllCategoryNames();

        bool isParent(int id);

    }
}