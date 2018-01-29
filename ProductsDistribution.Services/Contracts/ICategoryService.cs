using ProductsDistribution.Core.Category.Models;
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

        IEnumerable<string> GetAllCategoryNames();


    }
}