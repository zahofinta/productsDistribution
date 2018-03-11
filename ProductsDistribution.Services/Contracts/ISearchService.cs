using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsDistribution.Services.Contracts
{
    public interface ISearchService
    {
        IQueryable<String> GetProducersAndProductsNames(string name);
    }
}