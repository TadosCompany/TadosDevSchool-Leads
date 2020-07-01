namespace Leads.WebApi.Application.Infrastructure.Exceptions.Factories.Abstractions
{
    using System;
    using Domain.Exceptions;


    public interface IApiExceptionFactory
    {
        ApiException Create(ErrorCodes code);

        ApiException Create(ErrorCodes code, Exception innerException);

        ApiException MapException(DomainException exception);
    }
}