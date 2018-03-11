using ProductsDistribution.Data.Contracts;
using ProductsDistribution.Data.Repositories;
using ProductsDistribution.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services
{
   
        public class SearchService : ISearchService
        {
        public readonly SearchRepository SearchRepository;

        public SearchService(SearchRepository searchRepository)

        {
            this.SearchRepository = searchRepository;

        }
        public IQueryable<string> GetProducersAndProductsNames(string name)
            {
            return this.SearchRepository.GetProducersAndProductsNames(name);
            }
        }

    
}