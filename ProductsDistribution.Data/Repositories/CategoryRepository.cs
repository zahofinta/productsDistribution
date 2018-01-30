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
        public List<string> GetAllCategoryNames()
        {
            var categories = this._dbSet;
            return categories.Select(x => x.category_name).ToList();
        }

        public List<string> GetAllSubCategories(string categoryName)
        {
            var categories = this._dbSet;
            var sub_categories_names = (from c in categories
                                       where c.Category_parent_id == null && c.category_name.Equals(categoryName)
                                       from subcategory in categories
                                       where subcategory.Category_parent_id == c.category_id
                                       select subcategory.category_name).ToList();


            
            return sub_categories_names;
          //return categories.Where(x => x.category_name == categoryName && x.category_id == x.Category_parent_id).Select(x=>x.category_name).ToList();
        }

        public int GetCategoryId(string categoryName)
        {
            var categories = this._dbSet;
            int category_id = categories.SingleOrDefault(x => x.category_name == categoryName).category_id;
            return category_id;
        }
    }
}