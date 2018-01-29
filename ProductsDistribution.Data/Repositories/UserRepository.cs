using Microsoft.AspNet.Identity;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserStore<User> userManager;

        public UserRepository(IUserStore<User> userManager)
        {
            this.userManager = userManager;
        }
    }
}