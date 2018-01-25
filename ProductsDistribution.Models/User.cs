using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace ProductsDistribution.Models
{
    public enum Gender { m,f}
    public class User : IdentityUser
    {

        private ICollection<Producer> producers;
        private ICollection<Query> queries;
        private ICollection<Announcement> announcements;

        public User()
        {
            this.producers = new HashSet<Producer>();
            this.queries = new HashSet<Query>();
            this.announcements = new HashSet<Announcement>();
        }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        [Min(1,ErrorMessage ="Please enter age greater than 1")]
        public int years { get; set; }
        [Required]
       
        public string post_address { get; set; }
        [Required]
        public string organization { get; set; }

        public string department { get; set; }
        [Required]
       // public string username { get; set; }

        public bool isEnabled { get; set; }

        public float rating { get; set; }

            public virtual ICollection<Producer> Producers
        {
            get { return this.producers; }
            set { this.producers = value; }
        }

        public virtual ICollection<Query> Queries
        {
            get { return this.queries; }
            set { this.queries = value; }
        }

        public virtual ICollection<Announcement> Announcements
        {
            get { return this.announcements; }
            set { this.announcements = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}