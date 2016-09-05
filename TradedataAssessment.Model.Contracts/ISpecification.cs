using System;
using System.Linq.Expressions;

namespace TradedataAssessment.Model.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfied();
    }
}