using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace TradedataAssessment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEnumerable<DbContext> _dbContexts;

        private bool _shouldCancelSaving;

        public UnitOfWork(IEnumerable<DbContext> dbContexts)
        {
            _dbContexts = dbContexts;
        }

        public void SaveChanges()
        {

            if (!_shouldCancelSaving)
            {
                foreach (var dbContext in _dbContexts)
                {
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        throw;
                    }
                }
            }
            else
            {
            }

        }

        public void CancelSaving()
        {
            _shouldCancelSaving = true;
        }
    }
}
