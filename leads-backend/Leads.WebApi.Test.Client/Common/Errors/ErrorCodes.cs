namespace Leads.WebApi.Test.Client.Common.Errors
{
    public enum ErrorCodes
    {
        UnknownError = 0,
        UserAlreadyExists = 1,
        EmailOrPasswordIsIncorrect = 2,
        UserNotFound = 3,
        PasswordIsTooWeak = 4,
        ClientSourceAlreadyExists = 5,
        ClientSourceNotFound = 6,
        ClientSourceExistsButDeleted = 7,
        UserExistsButDeleted = 8,
    }
}