using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models
{
    public enum Status
    { Opened,In_Progress,Closed}
    public class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int announcement_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime arrive_date { get; set; }

        public bool isEnabled { get; set; }

        public Status status { get; set; }

        public User user { get; set; }

        public ICollection<AnnouncementToProduct> announcements_to_products { get; set; }
    }
}