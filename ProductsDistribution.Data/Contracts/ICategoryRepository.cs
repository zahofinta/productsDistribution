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
        List<string> GetAllCategoryNames();

        List<string> GetAllSubCategories(string categoryName);

    }
}