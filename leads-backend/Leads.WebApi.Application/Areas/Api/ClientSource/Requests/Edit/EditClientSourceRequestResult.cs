namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Edit
{
    using Dto;
    using Infrastructure.Requests.Results;


    public class EditClientSourceRequestResult : IApiRequestResult
    {
        public EditClientSourceRequestResult(ClientSourceDto clientSource)
        {
            ClientSource = clientSource;
        }


        public ClientSourceDto ClientSource { get; }
    }
}