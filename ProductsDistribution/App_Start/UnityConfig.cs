using System;
using ProductsDistribution.Data;
using ProductsDistribution.Models;

using Unity;
using Microsoft.AspNet.Identity;
using Unity.Injection;
using Microsoft.Owin.Security;
using System.Web;
using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Data.Repositories;
using ProductsDistribution.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

using ProductsDistribution.Core;
using Unity.Lifetime;
using ProductsDistribution.Services.Contracts;
using ProductsDistribution.Services;
using Unity.AspNet.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace ProductsDistribution
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<DbContext, ProductsDistributionDBContext>();
            //Беше добавено допълнително 
            //container.RegisterType<UserManager<User>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<User>, UserStore<User>>(new HierarchicalLifetimeManager());

          

            //Беше добавено new ProductsDistributionDBContext() w konstruktora  InjectionConstructor
            // container.RegisterType<IUserStore<User>, UserStore<User>>(new InjectionConstructor(typeof(ProductsDistributionDBContext)));
            container.RegisterType<IUserStore<User>, UserStore<User>>(new InjectionConstructor(new ProductsDistributionDBContext()));
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IRepository<Category>, GenericEfRepository<Category>>();
            container.RegisterType<IRepository<Product>, GenericEfRepository<Product>>();
            container.RegisterType<IRepository<Producer>, GenericEfRepository<Producer>>();
            container.RegisterType<IRepository<ProducerToProduct>, GenericEfRepository<ProducerToProduct>>();
            //container.RegisterType<IIncomeRepository, IncomeRepository>();

            //container.RegisterType<IPaymentService, PaymentService>();
            //container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProducerService, ProducerService>();
            container.RegisterType<IProducerToProductService, ProducerToProductService>();

            container.RegisterType<AccountController>(new InjectionConstructor(typeof(ApplicationUserManager), typeof(ApplicationSignInManager), typeof(IAuthenticationManager)));
             container.RegisterType<ManageController>(new InjectionConstructor(typeof(ApplicationUserManager), typeof(ApplicationSignInManager), typeof(IAuthenticationManager)));
        }
    }
}