﻿using DataAnnotationsExtensions;
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
        public string userId { get; set; }

        [Required(ErrorMessage = "Име на продукт е задължително поле")]
        [Display(Name = "Име на продукт :")]
        public string product_name { get; set; }
        [Required(ErrorMessage = "Описание на продукт е задължително поле")]
        [Display(Name = "Описание на продукта :")]
        public string product_description { get; set; }

        [Display(Name = "Разфасовка :")]
        public string cut { get; set; }
        [Required(ErrorMessage = "Тегло е задължително поле")]
        [Display(Name = "Тегло :")]
        [Min(0.0, ErrorMessage = "Въведете тегло по-голямо от 0")]
        public double weight { get; set; }
        [Required(ErrorMessage = "Тегло е задължително поле")]
        [Min(0.0, ErrorMessage = "Въведете обем по-голям от 0")]
        [Display(Name = "Обем :")]
        public double volume { get; set; }
        //[Required]

        [DataType(DataType.Date)]
        [Display(Name = "Трайност :")]
        //[Display(Name = "Трайност"),DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}")]
        public DateTime durability { get; set; }

        [Display(Name = "Допълнение към описанието :")]
        public string other { get; set; }

        [Required]
        [Display(Name = "Мерна единица :")]
        public string selected_unit { get; set; }

        //public string selected_ParentCategory{ get; set; }
        [Required(ErrorMessage = "Категория е задължително поле")]
        public string selected_category { get; set; }


        [Display(Name = "Разфасовка :")]
        public string selected_cut { get; set; }


        //[Required(ErrorMessage = "Категория е задължително поле")]
        //[Display(Name = "Kатегория :")]
        //public IEnumerable<SelectListItem> parent_categories = new List<SelectListItem>();
        //[Required(ErrorMessage = "Подкатегория е задължително поле")]
        //[Display(Name = "Подкатегория :")]
        //public IEnumerable<SelectListItem> child_categories = new List<SelectListItem>();

        [Required(ErrorMessage = "Мерна единица е задължително поле")]
        [Display(Name = "Мерна единица :")]
        public IEnumerable<SelectListItem> units = new List<SelectListItem>();


        [Display(Name = "Разфасовка:")]
        public IEnumerable<SelectListItem> cuts = new List<SelectListItem>();
    }
}