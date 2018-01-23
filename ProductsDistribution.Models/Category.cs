using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsDistribution.Models
{
    public class Category
    {
        private ICollection<Product> products;
        [Key]
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        [Required]
        public string category_description { get; set; }

        [ForeignKey("parent_Category")]
        public int? Category_parent_id { get; set; }

        public Category parent_Category { get; set; }

        public ICollection<Category> children { get; set; }

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}