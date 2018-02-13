using ProductsDistribution.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Windows.Forms;

namespace ProductsDistribution.Data.Repositories
{
    public class GenericEfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public GenericEfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// The method will use LINQ SingleOrDefault to search for an entity 
        /// in the data context.
        /// </summary>
        /// <param name="lambdaExpression"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, Boolean>> lambdaExpression)
        {
            return _dbSet.FirstOrDefault(lambdaExpression);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, Boolean>> lambdaExpression = null)
        {
            if (lambdaExpression != null)
                return _dbSet.Where(lambdaExpression);
            else
                return _dbSet;
        }

        public void Insert(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
            _dbContext.SaveChanges();
           
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            _dbContext.SaveChanges();
        }

        #region Private Methods
        private TEntity ChangeState(TEntity entity, EntityState state)
        {
            var entry = this._dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._dbSet.Add(entity);
            }

            entry.State = state;
            return entity;
        }

        #endregion

        #region IDispose And Finalizer

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                    _dbContext.Dispose();
                if (_dbSet != null)
                    _dbSet = null;
            }
        }

        ~GenericEfRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}