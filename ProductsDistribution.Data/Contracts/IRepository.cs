using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ProductsDistribution.Core.Product.Models;

namespace ProductsDistribution.Data.Contracts
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity Get(Expression<Func<TEntity, Boolean>> lambdaExpression);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, Boolean>> lambdaExpression = null);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        
    }
}