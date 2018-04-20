using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Models.InputModels
{
    public class AnnouncementInfoInputModel
    {
        public AnnouncementInfoInputModel()
        {
            announcements = new List<AnnouncementInfo>();
          //  announcement = new AnnouncementInfo();
        }

       // public AnnouncementInfo announcement { get; set; }
        public List<AnnouncementInfo> announcements { get; set; }
    }
}