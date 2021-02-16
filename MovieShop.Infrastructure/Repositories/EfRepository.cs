using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieShop.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext; //protected: (access modifier) current class and the class have it can access
        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual T GetByIdAsync(int id)
        {
            var entity = _dbContext.Set<T>().Find(id); //use set<T> to replace genres,movies
            return entity;
        }
        public virtual IEnumerable<T> ListAllAsync()
        {
            return _dbContext.Set<T>().ToList();
        }
        public virtual IEnumerable<T> ListAsync(Expression<Func<T, bool>> filter)
        {
            var filterList = _dbContext.Set<T>().Where(filter).ToList();
            return filterList;
        }
        public virtual int GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter!=null)
            {
                return _dbContext.Set<T>().Where(filter).Count();
            }
            return _dbContext.Set<T>().Count();
        }
        public virtual bool GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter!=null)
            {
                return _dbContext.Set<T>().Where(filter).Any();
            }
            return false;
        }
        public virtual T AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();// send to the database to execute it!!!
            return entity;
        }
        public virtual T UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
        public virtual T DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T UpdatingAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
