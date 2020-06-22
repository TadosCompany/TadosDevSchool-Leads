namespace Infrastructure.Transactions.Behaviors
{
    public interface IPerformAutoCommit
    {
        void PreventAutoCommit();
    }
}