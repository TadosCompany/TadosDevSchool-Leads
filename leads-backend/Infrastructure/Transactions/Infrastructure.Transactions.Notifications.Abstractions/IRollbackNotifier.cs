namespace Infrastructure.Transactions.Notifications.Abstractions
{
    using System;


    public interface IRollbackNotifier
    {
        event EventHandler BeforeRollback;

        event EventHandler AfterRollback;
    }
}