using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsDistribution.Models.InputModels
{
    public class ProductInputEditModel
    { 
        public int product_id { get; set; }
        [Required(ErrorMessage = "Име на продукт е задължително поле")]
        [Display(Name = "Име на продукт :")]
        public string product_name { get; set; }
        [Required(ErrorMessage = "Описание на продукт е задължително поле")]
        [Display(Name = "Описание на продукта :")]
        public string product_description { get; set; }
        [Required(ErrorMessage = "Разфасовка е задължително поле")]
        [Display(Name = "Разфасовка :")]
        public string cut { get; set; }
        [Required(ErrorMessage = "Тегло е задължително поле")]
        [Display(Name = "Тегло :")]
        [Min(0.0, ErrorMessage = "Въведете тегло по-голямо от 0")]
        public double weight { get; set; }
        [Min(0.0, ErrorMessage = "Въведете обем по-голям от 0")]
        [Display(Name = "Обем :")]
        public double volume { get; set; }
        [Required]
        [Min(0.1, ErrorMessage = "Въведете цена по-голяма от 0.1")]
        [Display(Name = "Цена :")]
        public double price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Трайност :")]
        public DateTime durability { get; set; }
        [Display(Name = "Допълнение към описанието :")]
        public string other { get; set; }

        [Required(ErrorMessage = "Категория е задължително поле")]
        public string selected_ParentCategory { get; set; }
        [Required(ErrorMessage = "Подкатегория е задължително поле")]
        public string selected_ChildCategory { get; set; }


        [Required(ErrorMessage = "Категория е задължително поле")]
        [Display(Name = "Kатегория :")]
        public IEnumerable<SelectListItem> parent_categories = new List<SelectListItem>();
        [Required(ErrorMessage = "Подкатегория е задължително поле")]
        [Display(Name = "Подкатегория :")]
        public IEnumerable<SelectListItem> child_categories = new List<SelectListItem>();
    }
}