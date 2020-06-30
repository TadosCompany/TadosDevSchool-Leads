#if DEBUG
namespace Leads.WebApi.Application.Infrastructure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::Infrastructure.Transactions.Notifications.Abstractions;
    using Microsoft.Extensions.Logging;


    public class LoggerEmailMessageSender : IEmailMessageSender, IDisposable
    {
        private readonly ILogger<LoggerEmailMessageSender> _logger;
        private readonly ICommitNotifier _commitNotifier;
        private readonly List<string> _messages = new List<string>();


        public LoggerEmailMessageSender(
            ILogger<LoggerEmailMessageSender> logger,
            ICommitNotifier commitNotifier)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commitNotifier = commitNotifier ?? throw new ArgumentNullException(nameof(commitNotifier));
            _commitNotifier.AfterCommit += CommitNotifierOnAfterCommit;
        }

        private void CommitNotifierOnAfterCommit(object sender, EventArgs e)
        {
            foreach (var message in _messages)
            {
                _logger.LogWarning(message);
            }
        }


        public Task SendMessageAsync(string email, string subject, string body)
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("New message")
                .AppendLine()
                .AppendLine($"To: {email}")
                .AppendLine($"Subject: {subject}")
                .AppendLine()
                .AppendLine(body);

            _messages.Add(stringBuilder.ToString());

            return Task.CompletedTask;
        }


        public void Dispose()
        {
            if (_commitNotifier != null)
                _commitNotifier.AfterCommit -= CommitNotifierOnAfterCommit;
        }
    }
}
#endif