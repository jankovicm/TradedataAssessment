using System.Linq;
using Tradedataassessment.Model;

namespace TradedataAssessment.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TradedataEntities _dbContext;

        public Repository(TradedataEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Add<T2>(T2 entity) where T2 : class
        {
            _dbContext.Set<T2>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public virtual void Delete<T2>(T2 entity) where T2 : class
        {
            _dbContext.Set<T2>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return FindAll<T>();
        }

        public IQueryable<T2> FindAll<T2>() where T2 : class
        {
            return _dbContext.Set<T2>();
        }

        public virtual T Get(int id)
        {
            return Get<T>(id);
        }

        public virtual T2 Get<T2>(params object[] keyValues) where T2 : class
        {
            return _dbContext.Set<T2>().Find(keyValues);
        }
    }
}