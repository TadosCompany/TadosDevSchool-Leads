namespace Leads.WebApi.Application
{
    public static class ErrorCodes
    {
        public const long UserAlreadyExists = 1;
        public const long EmailOrPasswordIsIncorrect = 2;
        public const long UserNotFound = 3;
        public const long PasswordIsTooWeak = 4;
        public const long ClientSourceAlreadyExists = 5;
        public const long ClientSourceNotFound = 6;
    }
}