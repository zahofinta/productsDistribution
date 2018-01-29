using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDistribution.Core.Category.Models;
using System.Data.Entity;

namespace ProductsDistribution.Data.Repositories
{
    public class CategoryRepository : GenericEfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<string> GetAllCategoryNames()
        {
            var categories = this._dbSet;
            return categories.Select(x => x.category_name);
        }

        public int GetCategoryId(string categoryName)
        {
            var categories = this._dbSet;
            int category_id = categories.SingleOrDefault(x => x.category_name == categoryName).category_id;
            return category_id;
        }
    }
}