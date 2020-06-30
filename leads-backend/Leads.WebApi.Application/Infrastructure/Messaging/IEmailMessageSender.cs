namespace Leads.WebApi.Application.Infrastructure.Messaging
{
    using System.Threading.Tasks;


    public interface IEmailMessageSender
    {
        Task SendMessageAsync(
            string email, 
            string subject,
            string body);
    }
}