namespace TradedataAssessment.Data
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        void CancelSaving();
    }
}