namespace Leads.WebApi.Test.Tests.Common
{
    public static class SharedData
    {
        public static readonly (string Email, string Password) AdminCredentials = ("admin@domain.com", "admin12345");

        public static readonly (string Email, string Password) ManagerCredentials =
            ("manager@domain.com", "manager12345");

        public static readonly (string Email, string Password) MarketerCredentials =
            ("marketer@domain.com", "marketer12345");
    }
}