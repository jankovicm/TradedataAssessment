using TradedataAssessment.Data;
using TradedataAssessment.Model.Contracts;

namespace TradedataAssessment.Service.Interfaces
{
    public interface IService<TModel> where TModel : class, IEntity
    {
        IRepository<TModel> Repository { get; }
    }

    public abstract class ServiceBase<TModel> : IService<TModel> where TModel : class, IEntity
    {
        public IRepository<TModel> Repository { get; private set; }

        protected ServiceBase(IRepository<TModel> repository)
        {
            Repository = repository;
        }
    }
}