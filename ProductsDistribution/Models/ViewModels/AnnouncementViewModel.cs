using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        public int announcement_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime arrive_date { get; set; }

        [Required]

        public string title { get; set; }

        public DateTime publish_date { get; set; }

        public AnnouncementViewModel()
        {

        }
    }
}