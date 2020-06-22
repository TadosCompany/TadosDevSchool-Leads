namespace Infrastructure.Transactions.Behaviors
{
    public interface IExpectCommit
    {
        void PerformCommit();
    }
}