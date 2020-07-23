#if DEBUG
namespace Leads.WebApi.Application.Infrastructure.Messaging
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class LoggerEmailMessageSender : IEmailMessageSender
    {
        private readonly ILogger<LoggerEmailMessageSender> _logger;


        public LoggerEmailMessageSender(ILogger<LoggerEmailMessageSender> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

            _logger.LogWarning(stringBuilder.ToString());

            return Task.CompletedTask;
        }
    }
}
#endif