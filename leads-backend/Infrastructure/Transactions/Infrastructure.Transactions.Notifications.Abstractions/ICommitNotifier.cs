namespace Infrastructure.Transactions.Notifications.Abstractions
{
    using System;


    public interface ICommitNotifier
    {
        event EventHandler BeforeCommit;

        event EventHandler AfterCommit;
    }
}