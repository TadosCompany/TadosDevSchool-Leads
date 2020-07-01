namespace Leads.WebApi.Application
{
    using Domain.Clients.Exceptions;
    using Domain.Users.Exceptions;
    using Infrastructure.Exceptions.Attributes;


    public enum ErrorCodes
    {
        [DefaultMessage("Unknown error")]
        UnknownError = 0,
        
        [DefaultMessage("User already exists")]
        [MapFromException(typeof(UserAlreadyExistsException))]
        UserAlreadyExists = 1,

        [DefaultMessage("Email or password is incorrect")]
        EmailOrPasswordIsIncorrect = 2,

        [DefaultMessage("User not found")]
        UserNotFound = 3,

        [DefaultMessage("Password is too weak")]
        [MapFromException(typeof(PasswordIsTooWeakException))]
        PasswordIsTooWeak = 4,

        [DefaultMessage("Client source already exists")]
        [MapFromException(typeof(ClientSourceAlreadyExistsException))]
        ClientSourceAlreadyExists = 5,

        [DefaultMessage("Client source not found")]
        ClientSourceNotFound = 6,
        
        [DefaultMessage("Client source with specified name already exists but deleted")]
        [MapFromException(typeof(ClientSourceExistsButDeletedException))]
        ClientSourceExistsButDeleted = 7,
        
        [DefaultMessage("User with specified email exists but deleted")]
        [MapFromException(typeof(UserExistsButDeletedException))]
        UserExistsButDeleted = 8,
    }
}