using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TodoTasks.Services
{
    public class EntityFrameworkRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {

        DatabaseContext _dbContext;


        public EntityFrameworkRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;

         


        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity GetById(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetLoadRerefence(string propertyName = null)
        {
            return _dbContext.Set<TEntity>().Include(propertyName).ToList();
        }

        public IEnumerable<TEntity> GetLoadRerefence(Expression<Func<TEntity, bool>> predicate, string propertyName1 = null)
        {
            return _dbContext.Set<TEntity>().Where(predicate).Include(propertyName1);

        }

        public int Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Insert(object entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }


      

    }
}
