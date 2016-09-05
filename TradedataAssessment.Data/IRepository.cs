using System.Linq;

namespace TradedataAssessment.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Add<T2>(T2 entity) where T2 : class;

        void Delete(T entity);

        void Delete<T2>(T2 entity) where T2 : class;

        T Get(int id);

        T2 Get<T2>(params object[] keyValues) where T2 : class;

        IQueryable<T> FindAll();

        IQueryable<T2> FindAll<T2>() where T2 : class;

        void SaveChanges();
    }
}