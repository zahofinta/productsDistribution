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
        public List<string> GetAllCategoryParentNames()
        {
            var categories = this._dbSet;
            return categories.Where(x => x.Category_parent_id == null).Select(x => x.category_name).ToList();
        }


        List<Category> GetChildren(List<Category> categories, int id)
        {
            return categories
                .Where(x => x.Category_parent_id == id)
                .Union(categories.Where(x => x.Category_parent_id == id)
                    .SelectMany(y => GetChildren(categories, y.category_id))
                ).ToList();
        }

        public List<string> GetAllSubCategories(string categoryName)
        {
            var categories = this._dbSet;
            var categories_filter_by_name = (from c in categories
                                             where c.category_name.Equals(categoryName) && c.Category_parent_id == null
                                             select c.category_name).ToList();


            var ress = GetChildren(categories.ToList(), GetCategoryId(categoryName));
            var sub_categories_names = (from c in categories
                                        where  c.category_name.Equals(categoryName) 
                                        from subcategory in categories 
                                        where subcategory.category_id == c.Category_parent_id
                                        select subcategory.category_name+ "->"+ c.category_name).ToList();

            var result = categories_filter_by_name.Union(sub_categories_names);

            return ress.Select(x=>x.category_name).ToList();
           // return result.ToList();
           // return sub_categories_names;
            //return categories.Where(x => x.category_name == categoryName && x.category_id == x.Category_parent_id).Select(x=>x.category_name).ToList();
        }

        public List<Category> GetFullSubCategories(string categoryName)
        {
            var categories = this._dbSet;
            var sub_categories = (from c in categories
                                  where c.Category_parent_id == null && c.category_name.Equals(categoryName)
                                  from subcategory in categories
                                  where subcategory.Category_parent_id == c.category_id
                                  select c).ToList();
            return sub_categories;
        }

        public CategoryDTO GetCategoryByName(string categoryName)
        {
            var categories = this._dbSet;
            var category = categories.SingleOrDefault(x => x.category_name == categoryName);

            return this.MapCategory(category);
        }

        public int GetCategoryId(string categoryName)
        {
            var categories = this._dbSet;
            int category_id=0;
            if (categoryName != "" && categoryName != null)
            {
                 category_id = categories.SingleOrDefault(x => x.category_name == categoryName).category_id;
            }
            return category_id;
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
        public List<CategoryDTO> GetAllSubCategoriesById(int id)
        {
            var categories = this._dbSet;
            List<CategoryDTO> sub_categories_dto = new List<CategoryDTO>();
            var sub_categories = (from c in categories
                                  where c.Category_parent_id == null && c.category_id == id
                                  from subcategory in categories
                                  where subcategory.Category_parent_id == c.category_id
                                  select subcategory).ToList();
            foreach (var category in sub_categories)
            {
                sub_categories_dto.Add(MapCategory(category));
            }
            return sub_categories_dto;
        }

        public List<string> GetAllCategoryNames()
        {
            var categories = this._dbSet;
            return categories.Select(x => x.category_name).ToList();
        }

        public int CountSubCategories(int id)
        {
            var categories = this._dbSet;
            int count_sub_categories = (from c in categories
                                  where c.Category_parent_id == null && c.category_id == id
                                  from subcategory in categories
                                  where subcategory.Category_parent_id == c.category_id
                                  select subcategory).Count();
          //  bool isParent = categories.Any(x => x.category_id == id && x.Category_parent_id == null);

            return count_sub_categories;
        }
    }

}