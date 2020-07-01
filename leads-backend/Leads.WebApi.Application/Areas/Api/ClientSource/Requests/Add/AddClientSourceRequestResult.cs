namespace Leads.WebApi.Application.Areas.Api.ClientSource.Requests.Add
{
    using Dto;
    using Infrastructure.Requests.Results;


    public class AddClientSourceRequestResult : IApiRequestResult
    {
        public AddClientSourceRequestResult(ClientSourceDto clientSource)
        {
            ClientSource = clientSource;
        }


        public ClientSourceDto ClientSource { get; }
    }
}