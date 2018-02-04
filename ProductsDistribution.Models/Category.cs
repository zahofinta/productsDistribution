using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Dynamic;

namespace ProductsDistribution.Models
{
    public class Category
    {
        private ICollection<Product> products;
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
        [Required(ErrorMessage = ("Име на категория е задължително поле"))]
        [StringLength(50)]
        [Index("category_nameIndex",IsUnique=true)]
        public string category_name { get; set; }
        [Required(ErrorMessage = ("Описание на категория е задължително поле"))]
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